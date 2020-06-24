using MVCDropDownListAjax.DesignPatterns.SingletonPattern;
using MVCDropDownListAjax.Models.Context;
using MVCDropDownListAjax.Models.Entities;
using MVCDropDownListAjax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDropDownListAjax.Controllers
{
    public class CityController : Controller
    {
        MyContext _db;
        public CityController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: City
        public ActionResult Index()
        {
            IndexVM ivm = new IndexVM
            {
                States = _db.States.ToList(),
                Cities = _db.Cities.ToList(),
                City = new Models.Entities.City()
            };
            if ( ivm.States.Count==0)
            {
                TempData["veriYok"] = "Önce sehir eklemelisiniz";
                return RedirectToAction("Index", "StateC");
            }
            return View(ivm);
        }

        [HttpPost]
        public ActionResult AddCity([Bind(Prefix = "City")]City item)
        {
            if (item.Name!=null && item.Name.Trim()!=string.Empty&&item.StateID!=0)
            {
                _db.Cities.Add(item);
                _db.SaveChanges();

            }
            else
            {
                TempData["eksikBilgi"] = "Lutfen alanları eksiksiz doldurunuz";
            }
            
            return RedirectToAction("Index");
        }
    }
}