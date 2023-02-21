using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System;

namespace MVCDemo.Controllers
{

    //  dependency injection
    public class CustomerController : Controller
    {


        ApplicationContext db= new ApplicationContext();


        //  Asp core  // New 
        public CustomerController()
        {
          
        }
        public IActionResult Index()
        {

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
        public IActionResult Create(  Customer customer)
        {

            var isvalid = ModelState.IsValid;
            if (customer.FirstName !=null &&   customer.FirstName.StartsWith("m"))
            {
                ModelState.AddModelError("FirstName", "يجب ادخال m "); 
            }

            if(ModelState.IsValid)
            {
               db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
           
        }





        [HttpPost]
        public IActionResult Login(Customer customer)
        {

      
             return View();

        }


    }
}
