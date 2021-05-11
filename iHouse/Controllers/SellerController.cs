using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iHouse.Models;

namespace iHouse.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller/Index
        public ActionResult Index()
        {
            iHouseEntities entities = new iHouseEntities();
            return View(entities.Sellers.ToList());

        }

        // GET: Seller/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Seller/Register
        [HttpPost]
        public ActionResult Register(Seller seller)
        {
            try
            {
                iHouseEntities entities = new iHouseEntities();
                entities.Sellers.Add(seller);
                entities.SaveChanges();
                return RedirectToAction("RegisterSucceeded");
            }
            catch
            {
                return RedirectToAction("RegisterFailed");
            }
        }

        // GET: Seller/RegisterSucceeded 
        public ActionResult RegisterSucceeded()
        {
            return View();

        }

        // GET: Seller/RegisterFailed 
        public ActionResult RegisterFailed()
        {
            return View();

        }

        //GET: Seller/Detail
        public ActionResult Detail(int SellerId)
        {
            iHouseEntities entities = new iHouseEntities();
            return View(entities.Sellers.Where(x => x.SellerId == SellerId).FirstOrDefault());

        }

        // GET: Seller/Update 
        public ActionResult Update()
        {
            return View();

        }

        //POST: Seller/Update
        [HttpPost]
        public string Update(int SellerId, string UserName, string FirstName, string LastName, string Email, string Phone, string Address)
        {
            iHouseEntities entities = new iHouseEntities();
            var item = entities.Sellers.Find(SellerId);
            item.UserName = UserName;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.Email = Email;
            item.Phone = Phone;
            item.Address = Address;
            entities.SaveChanges();
            return "Your account is updated";

        }

        // GET: Seller/Updated
        public ActionResult Updated()
        {
            return View();

        }

        //GET: Seller/Delete
        public ActionResult Delete()
        {
            return View();

        }
        //POST: Seller/Delete
        [HttpPost]
        public string Delete(int SellerId)
        {
            iHouseEntities entities = new iHouseEntities();
            Seller item = entities.Sellers.Find(SellerId);
            entities.Sellers.Remove(item);
            entities.SaveChanges();
            return "Your account is deleted";
        }
    }
}