using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Services;
using MVCDemo.ViewModels;

namespace MVCDemo.Controllers
{

    // Depenadnacey injection  //  Files 
    public class LanguageController : Controller
    {

       

        public LanguageController(IConfiguration configuration, IHostEnvironment hostEnvironment )
        {
 

        }
    

        ApplicationContext db = new ApplicationContext();

        public IActionResult Index()
        {
          
            var list = db.Languages.Select(a => new CreateLanguageVM() { Code = a.Code, Name = a.Name }).ToList();
            return View(list);
        }

        public IActionResult Create( )
        {
            //  
           
           //  LIst  Language Dto 
            return View();
        }



        //  Automapper 
        [HttpPost]
        public IActionResult Create(CreateLanguageVM  model )
        {
            if(ModelState.IsValid)
            {
                //  Auto mapper ... .....................
                var lange = new Language()
                {
                    Name = model.Name,
                    Code = model.Code,
                };

                //
                //
                //
                //
                //
                //
                //  register  automer 
                //  Register 
                db.Languages.Add(lange);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
