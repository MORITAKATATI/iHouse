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
        // GET: Index
        public ActionResult Index()
        {
            iHouseEntities entities = new iHouseEntities();
            return View(entities.Sellers.ToList());

        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(Seller seller)
        {
            try
            {
                iHouseEntities entities = new iHouseEntities();
                entities.Sellers.Add(seller);
                entities.SaveChanges();
                return RedirectToAction("Registered");
            }
            catch
            {
                return RedirectToAction("RegisterFailed");
            }
        }

        // GET: Register succeed 
        public ActionResult Registered()
        {
            return View();

        }

        // GET: Register failed 
        public ActionResult RegisterFailed()
        {
            return View();

        }

        // GET: Update
        public ActionResult Update()
        {
            return View();

        }
        [HttpPost]
       
        public string Update(int Id, string UserName, string FirstName, string LastName, string Email, string Phone, string Address)
        {
            iHouseEntities entities = new iHouseEntities();
            var item = entities.Sellers.Find(Id);
            item.UserName = UserName;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.Email = Email;
            item.Phone = Phone;
            item.Address = Address;
            entities.SaveChanges();
            return "Updated";

        }

        // GET: Updated
        public ActionResult Updated()
        {
            return View();

        }

        //GET: Delete
        public ActionResult Delete()
        {
            return View();

        }
        [HttpPost]
        public string Delete(int Id)
        {
            iHouseEntities entities = new iHouseEntities();
            Seller item = entities.Sellers.Find(Id);
            entities.Sellers.Remove(item);
            entities.SaveChanges();
            return "Deleted";
        }
    }
}