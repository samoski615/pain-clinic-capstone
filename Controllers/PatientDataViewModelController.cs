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
        public ActionResult Details()
        {
            //gets details about a patient's individual daily log

            var currentUserId = User.Identity.GetUserId();
            PatientDataViewModel viewModel = new PatientDataViewModel();
            viewModel.Patient = db.Patients.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();
            viewModel.DailyPainJournal = db.DailyPainJournals.Where(a => a.DailyPainJournalId == viewModel.Patient.PatientId).FirstOrDefault();



            if (viewModel.Patient == null)
            {
                return HttpNotFound();
            }

            return View(viewModel); 
        }

        // GET: PatientDataViewModel/Create
        public ActionResult CreateDailyLog()
        {
            var painRatingList = new List<string>() { "1", "2", "3", "4", "5" };
            ViewBag.painRatingList = painRatingList;

            var painLocationList = new List<string>() { "Upper Back", "Lower Back", "Neck", "Head", "Legs", "Arms", "Shoulders" };
            ViewBag.painLocationList = painLocationList;

            var amountOfSleepList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8 or more" };
            ViewBag.amountOfSleepList = amountOfSleepList;

            var activityLevelList = new List<string>() { "Sedentary", "Moderate", "High" };
            ViewBag.activityLevelList = activityLevelList;

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
                dataViewModel.DailyPainJournal.PatientId = currentPatient.PatientId;
                db.Entry(dataViewModel).State = EntityState.Added;
                db.SaveChanges();              
            }

            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return RedirectToAction("DailyLogList");     /////////REDIRECT TO A LIST OF DAILY LOGS OF THIS PATIENT -- fix view
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
        public ActionResult DailyLogList()
        {
            //gets a list of a patient's daily logs

            //1. user clicks 'Daily Journals' in navbar
            //2. get current user by User.Identity.GetUserId()
            //3. query for match by ApplicationId
            //4. if currentUser == patient I want, then include a list of daily pain logs of currently logged in patient in query, return a list

            PatientDataViewModel viewModel = new PatientDataViewModel();
            string currentUserId = User.Identity.GetUserId();
            Patient currentPatient = db.Patients.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();

            List<DailyPainJournal> journals = db.DailyPainJournals.Where(j => currentPatient.PatientId == j.PatientId).ToList();
                                                                                   

            ViewBag.dailyLogList = journals;

            //viewModel.GetDailyLogs = db.DailyPainJournals.Where(a => a.DailyPainJournalId == viewModel.Patient.PatientId).ToList();

            return View(journals);
        }
    }
}
