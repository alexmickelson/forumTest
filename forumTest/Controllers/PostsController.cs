using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using forumTest.Data;
using forumTest.Models;

namespace forumTest.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumsContext _context;

        public PostsController(ForumsContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postVM = new PostViewModel();
            postVM.Post = await _context.posts.FirstOrDefaultAsync(m => m.Id == id);
            if (postVM.Post == null)
            {
                return NotFound();
            }
            postVM.Comments = await _context.comments.Where(c => c.Post == id).ToListAsync();
            return View(postVM);
        }// GET: Posts/Details/5
        public async Task<IActionResult> DetailsWithComment(Guid postId, Guid commentId)
        {
            if (postId == null)
            {
                return NotFound();
            }
            var postVM = new PostViewModel();
            postVM.Post = await _context.posts.FirstOrDefaultAsync(m => m.Id == postId);
            if (postVM.Post == null)
            {
                return NotFound();
            }
            postVM.Comments = await _context.comments.Where(c => c.Post == postId).ToListAsync();

            ViewData["comment"] = commentId;
            return View("Details", postVM);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,User,Time")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = Guid.NewGuid();
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Text,User,Time")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _context.posts.FindAsync(id);
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _context.posts.Any(e => e.Id == id);
        }
    }
}
