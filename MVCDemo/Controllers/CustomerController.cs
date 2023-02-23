using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Extentions;
using MVCDemo.Models;
using System;
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
        public IActionResult Index()
        {
            //var imagePath = _configuration.GetSection("FilesPaths:pathImages").Value.ToString(); 
            var customers= db.Customers.ToList();

            return View(customers);
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

                   var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                   Helper.uploadFile(customer.MyFile, folderPath); 

                    db.Customers.Add(customer);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
            else
            {
                return View(customer);
            }
           
        }


     

    }
}
