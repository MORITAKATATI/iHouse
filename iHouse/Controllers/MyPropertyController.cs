using iHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace iHouse.Controllers
{
    public class MyPropertyController : Controller
    {
        private iHouseEntities entities = new iHouseEntities();

        // GET: MyProperty/Index
        public ActionResult Index()
        {
            return View();
        }

        //GET: MyProperty/Checkin
        [HttpPost]
        public ActionResult Checkin(int? SellerId, string Email)
        {
            //Check the input seller inf with db
            if (SellerId == null || Email == null)
            {
                TempData["CheckinFailed"] = "Invalid checkin, please try again";
                return View("Index");
            }

            List<Seller> sellers = entities.Sellers.Where(x => x.SellerId == SellerId & x.Email == Email).ToList();
            if (sellers.Count < 1)
            {
                TempData["CheckinFailed"] = "Invalid checkin, please try again";
                return View("Index");
            }
            return RedirectToAction("Me", new { SellerId = SellerId});
        }

        //POST: MyProperty/Me/5
        public ActionResult Me(int SellerId)
        {
            //Send seller inf to view
            Seller seller = entities.Sellers.Find(SellerId);

            //Send this seller's properties to view
            List<House> houses = entities.Houses.Where(a => a.SellerId == SellerId).OrderByDescending(a => a.HouseId).ToList();

            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }



        // GET: MyProperty/Add
        public ActionResult Add(int SellerId)
        {
            ViewBag.SellerId = SellerId;
            House house = new House()
            {
                SellerId = SellerId
            };
            return View(house);
        }

        // Post: MyProperty/Add
        [HttpPost]
        public ActionResult Add(House house, int? SellerId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entities.Houses.Add(house);
                    entities.SaveChanges();

                    //acknowledge message
                    TempData["SuccessMsg"] = "Property has been successfully added";

                    return RedirectToAction("Me", "MyProperty", new { SellerId = house.SellerId});
                }
                catch
                {
                    return View(house);
                }

            }
            return View(house);
        }


        // GET: MyProperty/Update/HouseId=5
        public ActionResult Update(int? id, int SellerId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = entities.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: MyProperty/Update/HouseId=5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int? id, int SellerId, House house)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                entities.Entry(house).State = EntityState.Modified;
                entities.SaveChanges();

                //acknowledge message
                TempData["SuccessMsg"] = "Property has been successfully updated";

                return RedirectToAction("Me", "MyProperty", new { SellerId = house.SellerId });
            }
            return View(house);
        }



        // GET: MyProperty/Delete/HouseId=5
        public ActionResult Delete(int? id, int SellerId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = entities.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: MyProperty/Delete/HouseId=5
        [HttpPost, ActionName("Delete")]
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int SellerId)
        {
            House house = entities.Houses.Find(id);
            var SelId = house.SellerId;
            entities.Houses.Remove(house);
            entities.SaveChanges();

            //acknowledge message
            TempData["SuccessMsg"] = "Property has been deleted";

            return RedirectToAction("Me", "MyProperty", new { SellerId = SelId });
        }
    }
}