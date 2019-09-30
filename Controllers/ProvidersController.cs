using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PainClinic.Models;
using Microsoft.AspNet.Identity;

namespace PainClinic.Controllers
{
    public class ProvidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Providers
        public async Task<ActionResult> Index()
        {
            return View(await db.Providers.ToListAsync());
        }

        // GET: Providers/Details/5
        //public ActionResult Details()
        //{
        //    var currentUserId = User.Identity.GetUserId();
        //    Provider provider = db.Providers.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();
           
        //    if (provider == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(provider);
        //}
            
        // GET: Hcps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(Provider provider)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var currentUserId = User.Identity.GetUserId();
        //        provider.ApplicationId = currentUserId;
        //        db.Providers.Add(provider);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(provider);
        //}

        // GET: Provider/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Provider provider = await db.Providers.FindAsync(id);
        //    if (provider == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(provider);
        //}

        // POST: Provider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        // GET: Provider/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Provider provider = await db.Providers.FindAsync(id);
        //    if (provider == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(provider);
        //}

        // POST: Provider/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Provider provider = await db.Providers.FindAsync(id);
        //    db.Providers.Remove(provider);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
