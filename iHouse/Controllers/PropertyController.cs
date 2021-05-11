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
            return View(entities.Houses.ToList());
        }

        // GET: Property/Add
        public ActionResult Add()
        {
            return View();
        }

        // Post: Property/Add
        [HttpPost]
        public ActionResult Add(House house)
        {
            try
            {
                iHouseEntities entities = new iHouseEntities();
                entities.Houses.Add(house);
                entities.SaveChanges();
                return RedirectToAction("ListSucceeded");
            }
            catch
            {
                return RedirectToAction("ListFailed");
            }
        }


        // GET: Property/ListSucceeded
        public ActionResult ListSucceeded()
        {
            return View();
        }

        // GET: Property/ListFailed
        public ActionResult ListFailed()
        {
            return View();
        }

        //GET: Property/Update 
        public ActionResult Update()
        {
            return View();

        }

        //POST: Property/Update 
        [HttpPost]
        public string Update(int HouseId, string Region, string Suburb, string Location, string Type, int Room, decimal FloorArea, decimal LandArea, decimal RV, string Email)
        {
            iHouseEntities entities = new iHouseEntities();
            var item = entities.Houses.Find(HouseId);
            item.HouseId = HouseId;
            item.Region = Region;
            item.Suburb = Suburb;
            item.Location = Location;
            item.Type = Type;
            item.Room = Room;
            item.FloorArea = FloorArea;
            item.LandArea = LandArea;
            item.RV = RV;
            item.Email = Email;
            entities.SaveChanges();
            return "This property has been updated";
        }

        //GET: Property/Delete
        public ActionResult Delete()
        {
            return View();

        }

        //POST: Property/Delete
        [HttpPost]
        public string Delete(int HouseId)
        {
            iHouseEntities entities = new iHouseEntities();
            House item = entities.Houses.Find(HouseId);
            entities.Houses.Remove(item);
            entities.SaveChanges();
            return "This property has been removed";
        }

        // POST: Property/Search
        [HttpPost]
        public ActionResult Search(string Region, string Suburb, string Type)
        {
            iHouseEntities entities = new iHouseEntities();
            List<House> SearchResult = entities.Houses.Where(x => x.Region.Contains(Region) & x.Suburb.Contains(Suburb) & x.Type.Contains(Type)).ToList();
            return View(SearchResult);

        }
    }
}