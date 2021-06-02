using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iHouse.Models;

namespace iHouse.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property/Index
        [HttpGet]
        public ActionResult Index()
        {
            iHouseEntities entities = new iHouseEntities();
            ViewBag.List = entities.Houses.OrderByDescending(x => x.HouseId).ToList();
            return View();
        }

        //Post: Property/Index
        [HttpPost]
        public ActionResult Index(string Region, string Suburb, string Type)
        {
            if (Region == null && Suburb== null && Type == null)
            {
                TempData["SeachFailed"] = "Please input at least one search condition";
                return View();
            }
            iHouseEntities entities = new iHouseEntities();
            List<House> SearchResult = entities.Houses
                                        .Where(x => x.Region.Contains(Region) & x.Suburb.Contains(Suburb) & x.Type.Contains(Type))
                                        .OrderByDescending(x => x.HouseId)
                                        .ToList();
            ViewBag.List = SearchResult;
            return View();
        }


    }
}