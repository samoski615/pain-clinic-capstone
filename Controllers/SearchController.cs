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
        public void SearchByPainLevel(string painLevel, string searchString)
        {

        }

        [HttpPost]
        public void SearchByPainLevel(string painLevel, string searchString, PatientDataViewModel viewModel)
        {

        }




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