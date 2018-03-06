using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bullify.Models;
using Bullify.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bullify.Controllers
{
    public class HomeController : Controller
    {

        private readonly BulliDatabaseRepository repository; //Genom att ta SaturnRepository här istället för SaturnContext så knyter vi inte vår HomeController riktigt lika hårt till vår databas!

        public HomeController(BulliDatabaseRepository repository) //Man nyar upp HomeController när hemsidan öppnas (och den här konstruktorn finns numera och måste följas, eftersom den parameterlösa konstruktorn per automatik då är borta)! Då anropas den här konstruktorn. När en instans av homecontroller skapas så måste man skapa en ny instans av Saturn Context! Den skapas automatiskt av MVC nu eftersom vi har reggat Saturnus för dependency injection (mvc kutar alltså över till StartUp-filen och ser att vi där möjliggjort för dependency injection)! HomeControllerns metoder kommer vilja hämta data i databasen (DÄRFÖR behöver vi en konstruktor för homecontrollern som tar in en instans av saturncontext över huvud taget)! OBS! Sen ändrade vi under håkans code-along från saturn context till saturnrepository!
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            var viewModel = repository.GetAllConsultants();
            return View(viewModel);
        }




        [HttpGet]
        [Route("Home/InfoBox/{id}")]
        public IActionResult InfoBox(int id)
        {
            var model = repository.GetConsultantById(id);
            return PartialView("_InfoBox", model);

          
        }


       
        
    }
}
