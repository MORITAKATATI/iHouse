using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iHouse.Models;
using System.Data.Entity;

namespace iHouse.Controllers
{
    public class MyPropertyController : Controller
    {
        // GET: MyProperty/Checkin
        public ActionResult Checkin()
        {
            return View();
        }

        //POST: MyProperty/Checkin
        [HttpPost]
        public ActionResult Checkin(int SellerId, string Email)
        {
            
            if (SellerId > 0 & Email != null)
            {
                return RedirectToAction("MyProperty", new { SellerId=SellerId, Email=Email});
            }
            else
            {
                return RedirectToAction("CheckinFailed");
            }

            

        }

        //GET:MyProperty/MyProperty
        public ActionResult MyProperty(int SellerId, string Email)
        {
            iHouseEntities entities = new iHouseEntities();
            MyProperty MyProperty = new MyProperty();
            MyProperty.sellers = entities.Sellers.Where(x => x.SellerId == SellerId & x.Email == Email).ToList();
            MyProperty.houses = entities.Houses.Where(a => a.SellerId == SellerId).ToList();
            return View(MyProperty);
            
        }

        //GET: MyProperty/CheckinFailed
        public ActionResult CheckinFailed()
        {
            return View();
        }

        //GET: MyProperty/Update 
        public ActionResult Update()
        {
            return View();

        }


        //POST:MyProperty/Update
        [HttpPost]
        public ActionResult Update(int HouseId,
                                //int SellerId, string Region, string Suburb, string Location,
                                //string Type, int Room, decimal FloorArea, decimal LandArea,
                                //decimal RV, string Email,
                                House house)
        {
            try
            {
                iHouseEntities entities = new iHouseEntities();
                //var item = entities.Houses.First(x => x.HouseId == HouseId);
                //item.HouseId = HouseId;
                //item.SellerId = SellerId;
                //item.Region = Region;
                //item.Suburb = Suburb;
                //item.Location = Location;
                //item.Type = Type;
                //item.Room = Room;
                //item.FloorArea = FloorArea;
                //item.LandArea = LandArea;
                //item.RV = RV;
                //item.Email = Email;

                entities.Entry(house).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("UpdateSucceed");
            }
            catch
            {
                return RedirectToAction("UpdateFailed");
            }
        }

        //GET: MyProperty/UpdateSucceed
        public ActionResult UpdateSucceed()
        {
            return View();
        }

        //GET: MyProperty/UpdateFailed
        public ActionResult UpdateFailed()
        {
            return View();
        }


        //GET: MyProperty/Delete
        public ActionResult Delete()
        {
            return View();

        }

        //POST: MyProperty/Delete
        [HttpPost]
        public ActionResult Delete(int HouseId)
        {
            iHouseEntities entities = new iHouseEntities();
            House house = entities.Houses.Find(HouseId);
            //List<House> item = entities.Houses.Where(x => x.HouseId == HouseId & x.SellerId == SellerId).ToList();
            entities.Houses.Remove(house);
            entities.SaveChanges();
            return RedirectToAction("Deleted");
        }


        //GET: MyProperty/Deleted
        public ActionResult Deleted()
        {
            return View();
        }
    }
}