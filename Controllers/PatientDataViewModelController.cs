﻿using Microsoft.AspNet.Identity;
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

                //currentPatient.PatientId = dataViewModel.Patient.PatientId; //figure out why this is erroring and not adding PatientId to dataModelView
                db.Entry(dataViewModel).State = EntityState.Modified;
                db.SaveChanges();

            }

            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details");
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
    }
}
