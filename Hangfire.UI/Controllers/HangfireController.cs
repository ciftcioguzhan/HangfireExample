using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.UI.Controllers
{
    public class HangfireController : Controller
    {
        // GET: HangfireController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HangfireController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HangfireController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangfireController/Create
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

        // GET: HangfireController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HangfireController/Edit/5
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

        // GET: HangfireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HangfireController/Delete/5
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
