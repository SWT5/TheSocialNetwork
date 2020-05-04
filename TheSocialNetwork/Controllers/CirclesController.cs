using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSocialNetwork.Models;
using TheSocialNetwork.Services;

namespace TheSocialNetwork.Controllers
{
    public class CirclesController : Controller
    {
        private readonly CircleService _circleService;

        public CirclesController(CircleService circleService)
        {
            this._circleService = circleService;
        }


        // GET: Cicles
        public ActionResult Index()
        {
            return View(_circleService.Get());
        }

        // GET: Cicles/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Cicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Circle circle)
        {
            try
            {
                _circleService.Create(circle); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    _circleService.Create(circle);
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(circle);
        }

        // GET: Cicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circle = _circleService.Get(id);
            if (circle == null)
            {
                return NotFound();
            }
            return View(circle);
        }

        // POST: Cicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Circle circle)
        {
            try
            {
                circle.CircleId = id; 
                _circleService.Update(id, circle);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(circle);
            }
        }

        // GET: Cicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circle = _circleService.Get(id);
            if (circle == null)
            {
                return NotFound();
            }
            return View(circle);
        }

        // POST: Cicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var circle = _circleService.Get(id);

                if (circle == null)
                {
                    return NotFound();
                }

                _circleService.Remove(circle.CircleId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}