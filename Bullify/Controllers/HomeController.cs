using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bullify.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("movie/infoBox/{id}")]
        public IActionResult MovieBox(int id)
        {
            var person = repository.GetPersonById(id);
            return PartialView("_InfoBox", new InfoBoxVM  
            {
                FirstName = person.FirstName,
                MovieSum = person.LastName
            });
        }

        [Route("settings/display")]
        public IActionResult Display(DisplayVM model)
        {
            model.Email = cache.Get<string>(magicString);
            model.Message = (string)TempData[magicString];
            model.CompanyName = HttpContext.Session.GetString(magicString);
            return View(model);
        }
    }
}
