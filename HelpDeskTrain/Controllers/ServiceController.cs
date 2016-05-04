using HelpDeskTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskTrain.Controllers
{
     [Authorize(Roles = "Администратор")]
    public class ServiceController : Controller
    {

        HelpdeskContext db = new HelpdeskContext();

        [HttpGet]
        public ActionResult Departments()
        {
            ViewBag.Departments = db.Departments;
            return View();
        }

        //Добавление отдела с последующим их отображением
        [HttpPost]
        public ActionResult Departments(Department depo)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(depo);
                db.SaveChanges();
            }
            ViewBag.Departments = db.Departments;
            return View(depo);
        }
        // Удаление отдела по id
        public ActionResult DeleteDepartment(int id)
        {
            Department depo = db.Departments.Find(id);
            db.Departments.Remove(depo);
            db.SaveChanges();
            return RedirectToAction("Departments");
        }

    }
}
