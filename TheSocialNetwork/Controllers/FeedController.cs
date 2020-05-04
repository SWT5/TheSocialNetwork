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
    public class FeedController : Controller
    {
        private readonly FeedService _feedService;

        public FeedController(FeedService feedService)
        {
            this._feedService = feedService;
        }

        // GET: Feed
        public ActionResult Index()
        {
            return View(_feedService.Get());
        }

        // GET: Feed/Details/5
        public ActionResult Details(string id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var feed = _feedService.Get(id);
            if (feed==null)
            {
                return NotFound();
            }
            return View(feed);
        }

        // GET: Feed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feed/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feed feed)
        {
            try
            {
                // TODO: Add insert logic here
                _feedService.Create(feed);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(feed);
            }
        }

        // GET: Feed/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = _feedService.Get(id);
            if (feed == null)
            {
                return NotFound();
            }

            return View(feed);
        }

        // POST: Feed/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Feed feed)
        {
            try
            {
                // TODO: Add update logic here
                _feedService.Update(id, feed);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(feed);
            }
        }

        // GET: Feed/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var feed = _feedService.Get(id);
            if (feed == null)
                return NotFound();

            return View(feed);
        }

        // POST: Feed/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var feed = _feedService.Get(id);
                if (feed == null)
                    return NotFound();
                _feedService.Remove(feed.FeedID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}