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
    public class StateCController : Controller
    {
        MyContext _db;
        public StateCController()
        {
            _db = DBTool.DBInstance;

        }
        // GET: StateC
        public ActionResult Index()
        {
            IndexVM ivm = new IndexVM()
            {
                States = _db.States.ToList(),
                State = new Models.Entities.State()

            };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult AddState([Bind(Prefix ="State")] State item)
        {
            if (item.Name != null && item.Name.Trim() != string.Empty)
            {
                _db.States.Add(item);
                _db.SaveChanges();
            }
            else TempData["eksikBilgi"] = "Lutfen alanları eksiksiz doldurunuz";

            return RedirectToAction("Index");
        }
    }
}