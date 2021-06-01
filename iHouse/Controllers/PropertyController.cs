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
        public ActionResult Index()
        {
            iHouseEntities entities = new iHouseEntities();
            return View(entities.Houses.OrderByDescending(x=>x.HouseId).ToList());
        }


        // POST: Property/Search
        [HttpPost]
        public ActionResult SearchResult(string Region, string Suburb, string Type)
        {
            iHouseEntities entities = new iHouseEntities();
            List<House> SearchResult = entities.Houses
                                        .Where(x => x.Region.Contains(Region) & x.Suburb.Contains(Suburb) & x.Type.Contains(Type))
                                        .OrderByDescending(x=>x.HouseId)
                                        .ToList();
            return View(SearchResult);

        }
    }
}