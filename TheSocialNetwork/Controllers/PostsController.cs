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
    public class PostsController : Controller
    {
        private readonly PostService postService;

        public PostsController(PostService postService)
        {
            this.postService = postService;
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View(postService.Get());
        }

        // GET: Posts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            try
            {
                // TODO: Add insert logic here

                postService.Create(post); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Post post)
        {
            try
            {
                // TODO: Add update logic here
                if(id != post.PostID)
                {
                    return NotFound();
                }
                
                postService.Update(id,post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(post);
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var post = postService.Get(id);
            if (post == null)
                return NotFound();

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var post = postService.Get(id);
                if (post == null)
                    return NotFound();

                postService.Remove(post.PostID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}