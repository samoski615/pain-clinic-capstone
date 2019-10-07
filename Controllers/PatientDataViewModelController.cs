using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using PainClinic.Models;
using PainClinic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            //PatientDataViewModel dataViewModel = new PatientDataViewModel();
            //string currentUserId = User.Identity.GetUserId();
            //Patient currentPatient = db.Patients.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();

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
                db.DailyPainJournals.Add(dataViewModel.DailyPainJournal);
                db.SaveChanges();              
            }

            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return RedirectToAction("DailyLogList");     
        }

        //GET: PatientDataViewModel/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientDataViewModel dataViewModel = await db.DailyPainJournals.FindAsync(id);
        //    if (dataViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dataViewModel);
        //}

        //// POST: PatientDataViewModel/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(PatientDataViewModel dataViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dataViewModel).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("DailyLogList");
        //    }
        //    return View(dataViewModel);
        //}
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

            List<DailyPainJournal> journals = db.DailyPainJournals.Where(j => currentPatient.PatientId == j.PatientId).OrderByDescending(j => j.LogDate).ToList();
                                                                                   

            ViewBag.dailyLogList = journals;
            return View(journals);
        }
        public ActionResult PatientList()
        {
            //gets a list of a patients for a current provider

            //1. user clicks 'PatientList' in navbar
            //2. show list of patients -- eventually make this a list of patients specific to the provider logged in -- need to match the ProviderId and PatientId

            List<Patient> patients = db.Patients.ToList();

            ViewBag.patients = patients;
            return View(patients);
        }

        public ActionResult PatientsDailyLogs(int? id)
        {
            //gets a list of a patient's daily logs

            Patient currentPatient = db.Patients.Where(p => p.PatientId == id).FirstOrDefault();

            List<DailyPainJournal> journals = db.DailyPainJournals.Where(j => currentPatient.PatientId == j.PatientId).OrderByDescending(j => j.LogDate).ToList();                                                              


            ViewBag.dailyLogList = journals;
            return View(journals);
        }


        //[HttpGet]
        public JsonResult Search(int? id)
        {
            //1. gets a list of DailyPainJournals for the last 30 days
            int nOfDays = 30;
            DateTime searchDate = DateTime.Today.Subtract(TimeSpan.FromDays(nOfDays));
            List<DailyPainJournal> dailyPainJournals = db.DailyPainJournals.Where(s => s.Patient.PatientId == id && s.LogDate > searchDate).ToList();


            //2. filters out the PainRating from the last 30 days journals
            //var painRatingList = dailyPainJournals.Select(s => s.PainRating).ToList();  //NOT WORKING///////////////////////////



            //var painRatingList = dailyPainJournals.Cast<List<object>>().Select(list => new DailyPainJournal()
            //{
            //    PainRating = (string)list[0]
            //}).ToList();

            //List<DailyPainJournal> dailyPainJournals = patientToQuery.Cast<DailyPainJournal>().Select(s => s.PainRating).ToList();

            return Json(dailyPainJournals, JsonRequestBehavior.AllowGet);

        }
        //[HttpPost]
        //public JsonResult SearchPainRating()
        //{
        //    //DateTime currentDate = DateTime.Today;
        //    DateTime searchDate = DateTime.Today.Subtract(TimeSpan.FromDays(30));

        //    //List <DailyPainJournal> patientToQuery = db.DailyPainJournals.Where(s => s.Patient.PatientId == id && s.LogDate > searchDate).ToList();
        //    var dailyPainJournals = patientToQuery.Select(s => s.PainRating).ToList();
            
        //    return Json(dailyPainJournals);

        //}


        [HttpPost]
        public JsonResult SearchByPainLevel(PatientDataViewModel viewModel)
        {
            //method that searches daily logs of a patient by their pain level score for the past 30 days 





            return Json(viewModel);
        }
    }
}
