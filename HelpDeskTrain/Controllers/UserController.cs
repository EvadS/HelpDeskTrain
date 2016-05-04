using HelpDeskTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Web.Mvc;


namespace HelpDeskTrain.Controllers
{
    [Authorize(Roles = "Администратор, Модератор, Исполнитель")]
    public class UserController : Controller
    {
        private HelpdeskContext db = new HelpdeskContext();
                                                                      
        [HttpGet]
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Department).Include(u => u.Role).ToList();
            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public ActionResult Create()
        {
            //списке мы будем видеть значения свойств Name, но при выборе фактически будут выбираться значения свойств Id.
            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;

            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;
           
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;
            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;

            return View(user);
        }

    }
}
