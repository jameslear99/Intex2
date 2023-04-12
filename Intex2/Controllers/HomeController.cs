using Intex2.Models;
using Intex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Intex2.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Intex2.Controllers
{
    public class HomeController : Controller
    {
        public IMummyProjectRepository repo;
        public HomeController(IMummyProjectRepository temp) => repo = temp;
        
        [HttpGet]
        public IActionResult DisplayList(string depth = "", string sex = "z", string headdirection = "z", string ageatdeath = "z", string haircolor = "z", string wrapping = "z", int pageNum = 1)
        {
            int totRecord = 0;
            int pageSize = 50;
            if (depth != "U" && depth != "" && depth != null)
            {
                //this is how we pass multiple things into the index page so we can access both the db and pagination info
                var x = new MummyViewModel
                {
                    Mummies = repo.Mummies /*It is able to return correct ranges for numbers, currently can't handle b.Depth's of null, U, or ""*/
                    .Where(b => b.Depth != "U" && b.Depth != null && b.Depth != "" && Convert.ToDecimal(b.Depth) <= Convert.ToDecimal(depth) && Convert.ToDecimal(b.Depth) > (Convert.ToDecimal(depth) - 1))
                    .Where(b => b.Sex == sex || sex == null || sex == "z")
                    .Where(b => b.Headdirection == headdirection || headdirection == null || headdirection == "z")
                    .Where(b => b.Ageatdeath == ageatdeath || ageatdeath == null || ageatdeath == "z")
                    .Where(b => b.Haircolor == haircolor || haircolor == null || haircolor == "z")
                    .Where(b => b.Wrapping == wrapping || wrapping == null || wrapping == "z")
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                    

                    PageInfo = new PageInfo
                    {
                        TotalNumMummy = repo.Mummies
                        .Where(b => b.Depth != "U" && b.Depth != null && b.Depth != "" && Convert.ToDecimal(b.Depth) <= Convert.ToDecimal(depth) && Convert.ToDecimal(b.Depth) > (Convert.ToDecimal(depth) - 1))
                        .Where(b => b.Sex == sex || sex == null || sex == "z")
                        .Where(b => b.Headdirection == headdirection || headdirection == null || headdirection == "z")
                        .Where(b => b.Ageatdeath == ageatdeath || ageatdeath == null || ageatdeath == "z")
                        .Where(b => b.Haircolor == haircolor || haircolor == null || haircolor == "z")
                        .Where(b => b.Wrapping == wrapping || wrapping == null || wrapping == "z")
                        .Count(),
                        MummyPerPage = pageSize,
                        CurrentPage = pageNum
                    }
                };
                x.SelectedDepth = depth;
                x.SelectedSex = sex;
                x.SelectedHeadDir = headdirection;
                x.SelectedAgeAtDeath = ageatdeath;
                x.SelectedHairColor = haircolor;
                x.SelectedWrapping = wrapping;

                return View(x);
            }
            else if (depth == "")
            {
                var x = new MummyViewModel
                {
                    Mummies = repo.Mummies
                    .Skip((pageNum - 1) * pageSize)
                    .Where(b => b.Sex == sex || sex == null || sex == "z")
                    .Where(b => b.Headdirection == headdirection || headdirection == null || headdirection == "z")
                    .Where(b => b.Ageatdeath == ageatdeath || ageatdeath == null || ageatdeath == "z")
                    .Where(b => b.Haircolor == haircolor || haircolor == null || haircolor == "z")
                    .Where(b => b.Wrapping == wrapping || wrapping == null || wrapping == "z")
                    .Take(pageSize),

                    PageInfo = new PageInfo
                    {
                        TotalNumMummy = repo.Mummies
                        .Where(b => b.Sex == sex || sex == null || sex == "z")
                    .Where(b => b.Headdirection == headdirection || headdirection == null || headdirection == "z")
                    .Where(b => b.Ageatdeath == ageatdeath || ageatdeath == null || ageatdeath == "z")
                    .Where(b => b.Haircolor == haircolor || haircolor == null || haircolor == "z")
                    .Where(b => b.Wrapping == wrapping || wrapping == null || wrapping == "z")
                        .Count(),
                        MummyPerPage = pageSize,
                        CurrentPage = pageNum
                    }
                };
                x.SelectedDepth = depth;
                x.SelectedSex = sex;
                x.SelectedHeadDir = headdirection;
                x.SelectedAgeAtDeath = ageatdeath;
                x.SelectedHairColor = haircolor;
                x.SelectedWrapping = wrapping;
                return View(x);
            }
            else
            {
                var x = new MummyViewModel
                {
                    Mummies = repo.Mummies
                    .Where(b => b.Sex == sex || sex == null || sex == "z")
                    .Where(b => b.Headdirection == headdirection || headdirection == null || headdirection == "z")
                    .Where(b => b.Ageatdeath == ageatdeath || ageatdeath == null || ageatdeath == "z")
                    .Where(b => b.Haircolor == haircolor || haircolor == null || haircolor == "z")
                    .Where(b => b.Wrapping == wrapping || wrapping == null || wrapping == "z")
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                    PageInfo = new PageInfo
                    {
                        TotalNumMummy = repo.Mummies
                    .Where(b => b.Sex == sex || sex == null || sex == "z")
                    .Where(b => b.Headdirection == headdirection || headdirection == null || headdirection == "z")
                    .Where(b => b.Ageatdeath == ageatdeath || ageatdeath == null || ageatdeath == "z")
                    .Where(b => b.Haircolor == haircolor || haircolor == null || haircolor == "z")
                    .Where(b => b.Wrapping == wrapping || wrapping == null || wrapping == "z")
                        .Count(),
                        MummyPerPage = pageSize,
                        CurrentPage = pageNum
                    }
                };
                x.SelectedDepth = depth;
                x.SelectedSex = sex;
                x.SelectedHeadDir = headdirection;
                x.SelectedAgeAtDeath = ageatdeath;
                x.SelectedHairColor = haircolor;
                x.SelectedWrapping = wrapping;
                return View(x);
            }
        }
        [HttpGet]
        public IActionResult Details(long Id)
        {

            var x = new MummyViewModel
            {
                Mummies = repo.Mummies,
                BridgeTable = repo.BridgeTable,
                Textiles = repo.Textiles
            };
            var Bridge = x.BridgeTable.Where(b => b.MainBurialmainid == Id).Select(b=> b.MainTextileid);
            long BridgeId = (long)Bridge.FirstOrDefault();
            var textile = x.Textiles.SingleOrDefault(t => t.Id == BridgeId);
            var Data = x.Mummies.Where(m => m.Id == Id);
            var Record = Data.FirstOrDefault();
            return View(Record);
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
        [Authorize]
        [HttpGet]
        public IActionResult AddEntry()
        {
            long LastId = repo.Mummies.Max(m => m.Id);
            var burialmain = repo.Mummies.ToList();

            ViewBag.Burialmain = burialmain;
            ViewBag.LastId = LastId + 1;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddEntry(Burialmain record)
        {
            repo.AddRecord(record);
            return RedirectToAction("DisplayList");
        }


        //adding textiles
        [HttpGet]
        public IActionResult AddTextile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTextile(Textile record)
        {
            repo.AddRecord(record);

            return RedirectToAction("DisplayList");
        }



        [Authorize]
        [HttpGet]
        public IActionResult EditBurialmain(long id)
        {
            var record = repo.GetById(id);
            return View(record);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditBurialmain(Burialmain record)
        {
            repo.UpdateRecord(record);
            return RedirectToAction("DisplayList");
        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteEntry(int id)
        {
            var record = repo.GetById(id);
            return View(record);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteEntry(long id)
        {
            var record = repo.GetById(id);
            repo.DeleteRecord(record);
            return RedirectToAction("DisplayList");
        }
/*        public IActionResult Confirmation()
        {

        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
