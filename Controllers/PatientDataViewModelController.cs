using Microsoft.AspNet.Identity;
using PainClinic.Models;
using PainClinic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Controllers
{
    public class PatientDataViewModelController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();


        // GET: PatientDataViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientDataViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientDataViewModel/Create
        public ActionResult CreateDailyLog()
        {
            return View();
        }

        //POST: PatientDataViewModel/Create
       [HttpPost]
        public ActionResult CreateDailyLog(PatientDataViewModel dataViewModel)
        {
            //method for creating a new daily pain log

            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                Patient currentPatient = db.Patients.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();
           
                currentPatient.DailyLogs = dataViewModel.GetDailyLogs;

                //db.Entry(currentPatient).State = EntityState.Modified;
                db.Entry(dataViewModel).State = EntityState.Added;
                db.SaveChanges();

            }
           
            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View("Details");
        }

        //GET: PatientDataViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientDataViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientDataViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientDataViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
