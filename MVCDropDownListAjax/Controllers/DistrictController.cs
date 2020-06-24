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
    public class DistrictController : Controller
    {
        MyContext _db;
        public DistrictController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: District
        public ActionResult Index()
        {
            IndexVM ivm = new IndexVM
            {
                States = _db.States.ToList(),
                Cities = _db.Cities.ToList(),
                Districts = _db.Districts.ToList(),
                District = new Models.Entities.District(),
            };

            if (ivm.Cities.Count == 0)
            {
                TempData["veriYok"] = "Önce ilçe eklemelisiniz";
                return RedirectToAction("Index", "City");
            }
            return View(ivm);
        }

        [HttpPost]
        public ActionResult AddDistrict([Bind(Prefix ="District")] District item)
        {
            if (item.Name != null && item.Name.Trim() != string.Empty && item.CityID != 0)
            {
                _db.Districts.Add(item);
                _db.SaveChanges();

            }
            else
            {
                TempData["eksikBilgi"] = "Lutfen alanları eksiksiz doldurunuz";
            }

            return RedirectToAction("Index");
        }

        public JsonResult GetCityByState(int id)
        {
            var result = _db.Cities.Where(x => x.StateID == id).Select(x => new
            {
                x.ID,
                x.Name
            }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}