﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parakeet.Models;

namespace parakeet.Controllers
{

    // THIS CONTROLLER CAN BE USED FOR TESTING IDEAS OR LAYOUTS WITHOUT MESSING WITH PRODUCTION CONTROLLERS
    public class TestController : Controller
    {
        // GET: TestController
        public ActionResult Index()
        {
            // testing the datetimes for orderhistory to see i can pull a specific orderhistory using date
            ViewData["date"] = DateTime.Today;
            DateTime order = (DateTime)TempData["date2"];
            ViewData["date2"] = TempData["date2"];
            if(DateTime.Today == order.Date)
            {
                ViewData["isEqual"] = true;
            }
            else
            {
                ViewData["isEqual"] = false;
            }
            return View();
        }

        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
