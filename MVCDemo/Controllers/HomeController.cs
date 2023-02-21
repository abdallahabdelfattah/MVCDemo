using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Services;
using System.Diagnostics;

namespace MVCDemo.Controllers
{

    //    Register   Services   ProductService >>     Instance >>      scoped , Singletone , transant 
    public class HomeController : Controller
    {


        public HomeController(

            ISingleToneProductService singleToneProductService1,
            IScopedProductService _scopedProductService1,
            ItransantProductService _transantProductService1,

            ISingleToneProductService singleToneProductService2,
            IScopedProductService _scopedProductService2,
            ItransantProductService _transantProductService2
            )
        {

            var id1= singleToneProductService1.Id;
            var id2 = singleToneProductService2.Id;

            var id3 = _scopedProductService1.Id;
            var id4 = _scopedProductService2.Id;




            var id5 = _transantProductService1.Id;
            var id6 = _transantProductService2.Id;
            //  servce1.getall()
        }

      
        public IActionResult Index()
        {


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}