using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        
       
        [Route("Search/Results")]
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.columns = searchType;
            ViewBag.title = searchType;
            if (searchTerm.Equals("all"))
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
            }

            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            return View("Index");
        }

    }
}
