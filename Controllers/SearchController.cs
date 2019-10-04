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
        public ActionResult SearchByPainRating(DateTime? currentDate, int id, PatientDataViewModel viewModel)
        {
            //search daily logs of a patient by their pain level score for the past 30 days 


            //get a list of PainRatings including list of dates

            List<DailyPainJournal> patientToSearch = db.DailyPainJournals.Where(s => s.PatientId == id).ToList();
            //patientToSearch.Where()
            //list of pain journals and dates of patient


            DateTime date30 = Convert.ToDateTime(30); //equals DateTime number 30
            currentDate = DateTime.Today;  //equals date today
            //searchDate = db.DailyPainJournals.Where(j => dateRange <= currentDate > date30);
            //if (currentDate > dateRange )
            //{
               
            //    return View(patientToSearch);
            //}




            return View();
        }
        //public ActionResult SearchByPainRating(string painRating, List<DateTime> searchDate, DateTime? currentDate, PatientDataViewModel viewModel)

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
