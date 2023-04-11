using Intex2.Models;
using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        public IMummyProjectRepository repo;
        public HomeController(IMummyProjectRepository temp) => repo = temp;



        public IActionResult DisplayList( int pageNum = 1)
        {
            int pageSize = 100;

            //this is how we pass multiple things into the index page so we can access both the db and pagination info
            var x = new MummyViewModel
            {
                Mummies = repo.Mummies
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumMummy = repo.Mummies.Count(),
                    MummyPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };


            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Supervised()
        {
            return View();
        }
        public IActionResult Unsupervised()
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
