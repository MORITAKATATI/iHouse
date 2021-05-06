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
        // GET: Property
        public ActionResult Index()
        {
            iHouseEntities entities = new iHouseEntities();
            return View(entities.Houses.ToList());
        }

        public ActionResult Add()
        {
            return View();

        }
    }
}