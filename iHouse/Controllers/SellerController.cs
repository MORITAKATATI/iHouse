using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iHouse.Models;

namespace iHouse.Controllers
{
    public class SellerController : Controller
    {
        private iHouseEntities entities = new iHouseEntities();
        // GET: Seller/Index
        public ActionResult Index()
        {
            
            return View();

        }
      

        // POST: Seller/Register
        [HttpPost]
        public ActionResult Register(Seller seller)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    entities.Sellers.Add(seller);
                    entities.SaveChanges();

                    //Success acknowledge message
                    TempData["SuccessMsg"] = "Successfully registered";

                    return RedirectToAction("Me", "MyProperty", new { SellerId = seller.SellerId});
                }
                catch
                {
                    return View("Index");
                }

            }
            return View("Index");
        }


        // GET: Seller/Update/SellerId=5
        public ActionResult Update(int? SellerId)
        {
            if (SellerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = entities.Sellers.Find(SellerId);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);

        }

        //POST: Seller/Update/SellerId=5
        [HttpPost]
        public ActionResult Update(int? SellerId, Seller seller)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    entities.Entry(seller).State = EntityState.Modified;
                    entities.SaveChanges();

                    //acknowledge message
                    TempData["SuccessMsg"] = "Your information has been successfully updated";

                    return RedirectToAction("Me", "MyProperty", new { SellerId = seller.SellerId});
                }
                catch
                {
                    return View();
                }
            }
            return View();

        }

    }
}