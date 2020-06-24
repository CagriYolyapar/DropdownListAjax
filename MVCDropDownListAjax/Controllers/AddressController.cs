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
    public class AddressController : Controller
    {
        MyContext _db;
        public AddressController()
        {
            _db = DBTool.DBInstance;
        }


        // GET: Address
        public ActionResult Index()
        {
            IndexVM ivm = new IndexVM()
            {
                States = _db.States.ToList(),
                Cities = _db.Cities.ToList(),
                Districts = _db.Districts.ToList(),
                Address = new Address(),
                Addresses = _db.Addresses.ToList()
            };
            if(ivm.Districts.Count == 0)
            {
                TempData["veriYok"] = "Lutfen önce mahalle ekleyin";
                return RedirectToAction("Index", "District");
            }
            return View(ivm);
        }

        [HttpPost]
        public ActionResult AddAddress([Bind(Prefix ="Address")] Address item)
        {
            if(item.Name!=null && item.Name.Trim()!=string.Empty && item.DistrictID != 0)
            {
                _db.Addresses.Add(item);
                _db.SaveChanges();
            }
            else
            {
                TempData["eksikVeri"] = "Lütfen tüm alanları eksiksiz doldurunuz";
            }
            return RedirectToAction("Index");

        }

        public JsonResult GetDistrictByCity(int id)
        {
            var result = _db.Districts.Where(x => x.CityID == id).Select(x => new
            {
                x.ID,
                x.Name

            }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
    }
}