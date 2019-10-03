using Microsoft.AspNetCore.Mvc;
using PainClinic.Models;
using PainClinic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Controllers
{
    public class SearchController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Search
        public ActionResult Index()
        {
            return View();
        }


        //[HttpGet]
        //public IActionResult DataVisualization(int? id)
        //{
        //    if (id == null)
        //    {
        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientDataViewModel viewModel = new PatientDataViewModel();
        //    if (id != null)
        //    {

        //        if (journals.)
        //        {

        //        }
        //    }

        //}

        //[HttpPost]
        //public async Task<IActionResult> DataVisualization(int? id)
        //{
        //    if (id == null)
        //    {
        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientDataViewModel viewModel = new PatientDataViewModel();
        //    if (id != null)
        //    {
        //        IQueryable<DailyPainJournal> journals = db.DailyPainJournals.Where(j => j.SearchDateStart >= SearchDateStart && j.Date <=

        //        if (journals.)
        //        {

        //        }
        //    }

        //}


        [HttpGet]
        public void SearchByDate(DateTime date)
        {

        }
        
        [HttpPost]
        public void SearchByDate(DateTime date, PatientDataViewModel viewModel)
        {

        }

        [HttpGet]
        public ActionResult SearchByPainLevel(string painLevel, DateTime searchDate, DateTime currentDate, PatientDataViewModel viewModel)
        {
            //search daily logs of a patient by their pain level score for the past 30 days (ie: from DateTime.now to -=30 DateTime.SearchDate


            //get a list of PainRatings
            viewModel = new PatientDataViewModel();
            List<string> patientToSearch = db.PatientDataViewModels.Where(j => j.Patient.PatientId == j.DailyPainJournal.PatientId)
                                                          .Select(j => j.DailyPainJournal.PainRating).ToList();  //list of pain journals of patient
            DateTime date = Convert.ToDateTime(30);
            currentDate = DateTime.Today;
            List<DateTime> dateRange = db.DailyPainJournals.Select(j => j.SearchDate).ToList();
            searchDate = db.DailyPainJournals.Where(j => dateRange <= currentDate > date);
            if (currentDate > dateRange )
            {
               
                return View(patientToSearch);
            }




            return View();
        }

        //[HttpPost]
        //public ActionResult SearchByPainLevel(string painLevel, string searchString, PatientDataViewModel viewModel)
        //{

        //}




        //public async Task<IActionResult> DataVisualization(int? id)
        //{
        //    if (id == null)
        //    {
        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientDataViewModel viewModel = new PatientDataViewModel();
        //    if (viewModel.Patient.PatientId == id)
        //    {
        //        IQueryable<DailyPainJournal> journals = db.DailyPainJournals;

        //        foreach (KeyValuePair<int, string> journal in journals)
        //        {
        //            switch (journal.Key)
        //            {
        //                case 1:
        //                    journals = journals.Where(j => j.DailyPainJournalId == int.Parse(journal.Value));
        //                    break;
        //                case 2:
        //                    journals = journals.Where(j => j.SearchDateStart.ToString() == (journal.Value));
        //                    break;
        //                case 3:
        //                    journals = journals.Where(j => j.PainRating == (journal.Value));
        //                    break;

        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //}

    }
}
