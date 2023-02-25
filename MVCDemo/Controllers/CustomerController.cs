using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Extentions;
using MVCDemo.Models;
using MVCDemo.Validation;
using MVCDemo.ViewModels;
using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MVCDemo.Controllers
{

    //  dependency injection
    public class CustomerController : Controller
    {


        ApplicationContext db= new ApplicationContext();
        private readonly IWebHostEnvironment _webHostEnvironment;
        IConfiguration _configuration;
        public CustomerController( IWebHostEnvironment webHostEnvironment, IConfiguration configuration )
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public IActionResult Index(CustomerFilterVM filter  )
        {
            var query = db.Customers.AsQueryable();  //  QUery Stament 
            if(filter.Gender!=null)
            {
                query= query.Where(a=>a.Gender==filter.Gender);  
            }
            if (filter.Search != null)
            {
                query = query.Where(a => 
                a.FirstName.Contains(filter.Search) ||
                a.LastName.Contains(filter.Search) 
                );
            }
            if (filter.From != null)
            {
                query = query.Where(a => a.BirthDate>= filter.From);
            }
            if (filter.To != null)
            {
                query = query.Where(a => a.BirthDate <= filter.From);
            }

            var customers= query.Select(a=> new CustomerVM()
            {
                FirstName=a.FirstName,
                LastName=a.LastName,
                Gender=a.Gender,
                ImagePath=a.ImagePath,
                Base64Image=a.Image!=null? Convert.ToBase64String(a.Image):"",
                CustomerId=a.CustomerId

            }).ToList();

            var dto = new ResponcesDto(); 
           dto.Customers=customers;
            dto.Filter = filter;
           
            return View(dto);
        }

      


        //  Create    Action    View 

        public IActionResult Create()
        {
            var model = new Customer(); 
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(  Customer customer )
        {


            if (ModelState.IsValid)
            {
                //  Save  File    Path  >> Insert  DB   //  name  // path 
                //  pdf 
                   var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                  var fileName=  Helper.uploadFile(customer.MyFile, folderPath); 
                    customer.ImagePath= fileName;


                //  Binary 
                //customer.MyFile
                //Helper.CheckFileSize(customer.MyFile);
                //Helper.CheckExtension()


                  var ms= new MemoryStream();
                  customer.MyFile.CopyTo(ms);
                  var arrayByte=  ms.ToArray();
                    customer.Image= arrayByte;

                    db.Customers.Add(customer);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
            else
            {
                return View(customer);
            }
           
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer= db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int customerId)
        {
            var customer = db.Customers.Find(customerId);
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
             var fullPath = folderPath + "//" + customer.ImagePath;
            Helper.DeleteFile(fullPath); 
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("index"); 
           
        }


    }
}
