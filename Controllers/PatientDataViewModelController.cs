using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        //public ActionResult GetPainRating(List<DailyPainJournal> journals)
        //{
        //    var getSearchResults = Search();

        //}


        public ActionResult SearchStatistics(int? id)
        {
            // gets a list of DailyPainJournals of a patient for the last 30 days
            int nOfDays = 30;
            DateTime searchDate = DateTime.Today.Subtract(TimeSpan.FromDays(nOfDays));
            List<DailyPainJournal> dailyPainJournals = db.DailyPainJournals.Where(s => s.Patient.PatientId == id && s.LogDate > searchDate).ToList();


            //filters dailyPainJournals from last 30 days and finds all Pain Ratings associated 
            List<string> painRatings = dailyPainJournals.Select(j => j.PainRating).ToList();

            var ratingOne = painRatings.Where(j => j.Contains("1")).ToList();
            var ratingOneCount = ratingOne.Count();

            var ratingTwo = painRatings.Where(j => j.Contains("2")).ToList();
            var ratingTwoCount = ratingTwo.Count();

            var ratingThree = painRatings.Where(j => j.Contains("3")).ToList();
            var ratingThreeCount = ratingThree.Count();

            var ratingFour = painRatings.Where(j => j.Contains("4")).ToList();
            var ratingFourCount = ratingFour.Count();

            var ratingFive = painRatings.Where(j => j.Contains("5")).ToList();
            var ratingFiveCount = ratingFive.Count();

            ViewBag.ratingOne = JsonConvert.SerializeObject(ratingOneCount);
            ViewBag.ratingTwo = JsonConvert.SerializeObject(ratingTwoCount);
            ViewBag.ratingThree = JsonConvert.SerializeObject(ratingThreeCount);
            ViewBag.ratingFour = JsonConvert.SerializeObject(ratingFourCount);
            ViewBag.ratingFive = JsonConvert.SerializeObject(ratingFiveCount);

            return View();

        }

        public ActionResult SearchPainLocation(int? id)
        {
            // gets a list of DailyPainJournals of a patient for the last 30 days
            int nOfDays = 30;
            DateTime searchDate = DateTime.Today.Subtract(TimeSpan.FromDays(nOfDays));
            List<DailyPainJournal> dailyPainJournals = db.DailyPainJournals.Where(s => s.Patient.PatientId == id && s.LogDate > searchDate).ToList();

            //filters dailyPainJournals from last 30 days and finds all Pain Locations associated 
            List<string> painLocations = dailyPainJournals.Select(j => j.PainLocation).ToList();

            var upperBack = painLocations.Where(j => j.Contains("Upper Back")).ToList();

            var ratingTwo = painLocations.Where(j => j.Contains("2")).ToList();
            var ratingThree = painLocations.Where(j => j.Contains("3")).ToList();
            var ratingFour = painLocations.Where(j => j.Contains("4")).ToList();
            var ratingFive = painLocations.Where(j => j.Contains("5")).ToList();
            var ratingFive = painLocations.Where(j => j.Contains("5")).ToList();
            var ratingFive = painLocations.Where(j => j.Contains("5")).ToList();

            ViewBag.ratingOne = JsonConvert.SerializeObject(ratingOne);
            ViewBag.ratingTwo = JsonConvert.SerializeObject(ratingTwo);
            ViewBag.ratingThree = JsonConvert.SerializeObject(ratingThree);
            ViewBag.ratingFour = JsonConvert.SerializeObject(ratingFour);
            ViewBag.ratingFive = JsonConvert.SerializeObject(ratingFive);

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
