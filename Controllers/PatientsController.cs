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
using PainClinic.Models.ViewModels;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace PainClinic.Controllers
{
    public class PatientsController : Controller
    {

        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public PatientRegistrationViewModel viewModel = new PatientRegistrationViewModel();

        // GET: Patients
        public ActionResult Index()
        {

            return View();
        }

        // GET: Patients/Details/5
        public ActionResult Details()
        {
            var currentUserId = User.Identity.GetUserId();
            PatientRegistrationViewModel viewModel = new PatientRegistrationViewModel();
            viewModel.Patient = db.Patients.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();

            //.Include(p => p.Addresses.StreetAddress)
            //.Include(p => p.Addresses.City)
            //.Include(p => p.Addresses.State)
            //.Include(p => p.Addresses.Zipcode)

            if (viewModel.Patient == null)
            {
                return HttpNotFound();
            }

            return View(viewModel); //determine what to show in the view aka "viewModel....."
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                viewModel.Patient.ApplicationId = currentUserId;
                var Patient = viewModel.Patient;
                var Address = viewModel.Address;
                db.Addresses.Add(Address);
                await db.SaveChangesAsync();
                Patient.AddressesId = db.Addresses.Select(a => a.AddressesId).FirstOrDefault();
                db.Patients.Add(Patient);
                await db.SaveChangesAsync();
                return RedirectToAction("Details");
            }

            return View(viewModel);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            PatientRegistrationViewModel viewModel = new PatientRegistrationViewModel();
            viewModel.Patient = db.Patients.Include(p => p.Addresses).Where(p => p.PatientId == id).FirstOrDefault();
            if (viewModel.Patient == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientRegistrationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }



            var Patient = viewModel.Patient.PatientId;
            _ = viewModel.Address.AddressesId;
            db.Entry(viewModel).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Details");
        }


        //GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRegistrationViewModel viewModel = new PatientRegistrationViewModel();
            viewModel.Patient = db.Patients.Include(p => p.Addresses).Where(p => p.PatientId == id).FirstOrDefault();
            if (viewModel.Patient == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        //POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            
            Patient patient = await db.Patients.FindAsync(id);

            var Patient = viewModel.Patient;
            var Address = viewModel.Address;

            db.Patients.Remove(Patient);
            db.Addresses.Remove(Address);
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

