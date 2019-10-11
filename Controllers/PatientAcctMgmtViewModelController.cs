﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PainClinic.Models;
using PainClinic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using Microsoft.AspNet.Identity;
using Stripe;
using System.Configuration;

namespace PainClinic.Controllers
{
    public class PatientAcctMgmtViewModelController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientAcctMgmtViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientAcctMgmtViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientAcctMgmtViewModel/Create
        public ActionResult GetClinicDirections()
        {
            return View("GoogleMapsAPI");
        }

        //POST: PatientAcctMgmtViewModel/Create
       //[HttpPost]
       // public async Task<IActionResult> GetClinicDirections(PatientAcctMgmtViewModel viewModel)
       // {
       //     if (ModelState.IsValid)
       //     {
       //         // api call
       //         //get the long and lat
       //         //add long and lat to viewModel
       //         viewModel = new PatientAcctMgmtViewModel();
       //         string apiCall = "https://maps.googleapis.com/maps/api/geocode/json?address=" + AddPluses(viewModel.Address.StreetAddress) + ",+" + AddPluses(viewModel.Address.City) + ",+" + AddPluses(viewModel.Address.State) + ",+" + AddPluses(viewModel.Address.Zipcode) + "&key=AIzaSyAY94W50Ro6315b5RFNT3TTUKMd3DsUrEU";
       //         HttpClient client = new HttpClient();
       //         //make a request for api call set up base address url 
       //         client.BaseAddress = new Uri(apiCall);
       //         HttpResponseMessage response = await client.GetAsync(apiCall);
       //         LocationInfo location = JsonConvert.DeserializeObject<LocationInfo>(await response.Content.ReadAsStringAsync());
       //         viewModel.Address.Latitude = location.Results[0].Geometry.Location.Lat;
       //         viewModel.Address.Longitude = location.Results[0].Geometry.Location.Lng;
       //         db.Entry(viewModel).State = EntityState.Added;
       //         await db.SaveChangesAsync();
       //         return RedirectToAction("");   //method to put here
       //     }
       //     return View(viewModel);
       // }

        public string AddPluses(string str)
        {
            str = str.Replace(" ", "+");
            return str;
        }

        public string AddCommas(string str)
        { 
            str = str.Replace(str, ",");
            return str;

        }


        //public async Task<IActionResult> PayBalance()
        //{
        //    return RedirectToActionAsync("Details", "Patients");
        //}


       
        public ActionResult Uploads()
        {
            //allow patient to upload forms
            foreach(string upload in Request.Files)
            {
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/uploads/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                }
            }
            return View("Uploads");
        }

        public ActionResult Downloads()
        {
            //allow patient to download forms
            var dir = new DirectoryInfo(Server.MapPath("~/App_Data/uploads/"));
            FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult DownLoad(string ImageName)
        {
            var FileVirtualPath = "~/App_Data/uploads/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }


        // GET: PatientAcctMgmtViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientAcctMgmtViewModel/Edit/5
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

        // GET: PatientAcctMgmtViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientAcctMgmtViewModel/Delete/5
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


        //GET: PatientRxRequest
        public ActionResult CreateRxRequest()
        {
            return View();
        }


        //POST: PatientRxRequest
        [HttpPost]
        public ActionResult CreateRxRequest(PatientAcctMgmtViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                Patient currentPatient = db.Patients.Where(p => p.ApplicationId == currentUserId).FirstOrDefault();
                viewModel.Prescription.PatientId = currentPatient.PatientId;
                currentPatient.IsRxRequested = true;
                db.Patients.Add(currentPatient);
                db.SaveChanges();
                //viewModel.Prescription.Patient.RxRequested = currentPatient.RxRequested;
                db.Prescriptions.Add(viewModel.Prescription);
                db.SaveChanges();

                //ViewBag.RxRequested = currentPatient.RxRequested;
            }

            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View("~/Views/Patients/PatientDetails.cshtml");

        }

        public ActionResult PayBalance(int? id)
        {
            var patient = db.Patients.Where(p => p.PatientId == id).Select(p=> p.PatientBalance);
            var stripePublishKey = ConfigurationManager.AppSettings["pk_test_GGKgYOyWOH5jcvN77SSjfXVT006hcxbAnV"];
            ViewBag.StripePublishKey = stripePublishKey;
            ViewBag.Patient = patient;
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var currentUserId = User.Identity.GetUserId();
            var patient = db.Patients.FirstOrDefault(m => m.ApplicationId== currentUserId);

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = Convert.ToInt64(patient.PatientBalance),
                Description = "Sample Charge",
                Currency = "usd",
                Customer = patient.PatientId.ToString()
            }); 
            patient.PatientBalance = 0;
            db.SaveChanges();
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
