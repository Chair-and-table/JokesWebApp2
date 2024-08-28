using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JokesWebApp2.Models;

namespace JokesWebApp2.Controllers
{
    public class JokesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jokes
        public async Task<ActionResult> Index()
        {
            return View(await db.Jokes.ToListAsync());
        }
        // Get : Jokes/ShowSearchForm
        public async Task<ActionResult> ShowSearchForm()
        {
            return View();
        }


        // GET: Jokes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joke joke = await db.Jokes.FindAsync(id);
            if (joke == null)
            {
                return HttpNotFound();
            }
            return View(joke);
        }

        // GET: Jokes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jokes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "JokeId,JokeQuestion,JokeAnswer")] Joke joke)
        {
            if (ModelState.IsValid)
            {
                db.Jokes.Add(joke);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(joke);
        }

        // GET: Jokes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joke joke = await db.Jokes.FindAsync(id);
            if (joke == null)
            {
                return HttpNotFound();
            }
            return View(joke);
        }

        // POST: Jokes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "JokeId,JokeQuestion,JokeAnswer")] Joke joke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joke).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(joke);
        }

        // GET: Jokes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joke joke = await db.Jokes.FindAsync(id);
            if (joke == null)
            {
                return HttpNotFound();
            }
            return View(joke);
        }

        // POST: Jokes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Joke joke = await db.Jokes.FindAsync(id);
            db.Jokes.Remove(joke);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
