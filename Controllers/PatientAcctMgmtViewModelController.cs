using Microsoft.AspNetCore.Mvc;
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
using static PainClinic.Models.Venue;
using System.Xml.Linq;

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

        public ActionResult ClinicLocation()
        {
            return View();
        }

        // GET: PatientAcctMgmtViewModel/Create
        public ActionResult GetClinicDirections()
        {
            List<Country> objCountry = new List<Country>();
            return View(new Venue { Countries = objCountry });
        }

        /// <summary>  
        /// This method is used to get the place list  
        /// </summary>  
        /// <param name="SearchText"></param>  
        /// <returns></returns>  
        [HttpGet, ActionName("GetEventVenuesList")]
        public JsonResult GetEventVenuesList(string SearchText)
        {
            string placeApiUrl = ConfigurationManager.AppSettings["GooglePlaceAPIUrl"];

            try
            {
                placeApiUrl = placeApiUrl.Replace("{0}", SearchText);
                placeApiUrl = placeApiUrl.Replace("{1}", ConfigurationManager.AppSettings["GooglePlaceAPIKey"]);

                var result = new System.Net.WebClient().DownloadString(placeApiUrl);
                var Jsonobject = JsonConvert.DeserializeObject<RootObject>(result);

                List<Prediction> list = Jsonobject.predictions;

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>  
        /// This method is used to get place details on the basis of PlaceID  
        /// </summary>  
        /// <param name="placeId"></param>  
        /// <returns></returns>  
        [HttpGet, ActionName("GetVenueDetailsByPlace")]
        public JsonResult GetVenueDetailsByPlace(string placeId)
        {
            string placeDetailsApi = ConfigurationManager.AppSettings["GooglePlaceDetailsAPIUrl"];
            try
            {
                Venue ven = new Venue();
                placeDetailsApi = placeDetailsApi.Replace("{0}", placeId);
                placeDetailsApi = placeDetailsApi.Replace("{1}", ConfigurationManager.AppSettings["GooglePlaceAPIKey"]);

                var result = new System.Net.WebClient().DownloadString(placeDetailsApi);

                var xmlElm = XElement.Parse(result);
                ven = GetAllVenueDetails(xmlElm);

                return Json(ven, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// This method is creted to get the place details from xml  
        /// </summary>  
        /// <param name="xmlElm"></param>  
        /// <returns></returns>  
        private Venue GetAllVenueDetails(XElement xmlElm)
        {
            Venue ven = new Venue();
            List<string> c = new List<string>();
            List<string> d = new List<string>();
            //get the status of download xml file  
            var status = (from elm in xmlElm.Descendants()
                          where
                              elm.Name == "status"
                          select elm).FirstOrDefault();

            //if download xml file status is ok  
            if (status.Value.ToLower() == "ok")
            {

                //get the address_component element  
                var addressResult = (from elm in xmlElm.Descendants()
                                     where
                                         elm.Name == "address_component"
                                     select elm);
                //get the location element  
                var locationResult = (from elm in xmlElm.Descendants()
                                      where
                                          elm.Name == "location"
                                      select elm);

                foreach (XElement item in locationResult)
                {
                    ven.Latitude = float.Parse(item.Elements().Where(e => e.Name.LocalName == "lat").FirstOrDefault().Value);
                    ven.Longitude = float.Parse(item.Elements().Where(e => e.Name.LocalName == "lng").FirstOrDefault().Value);
                }
                //loop through for each address_component  
                foreach (XElement element in addressResult)
                {
                    string type = element.Elements().Where(e => e.Name.LocalName == "type").FirstOrDefault().Value;

                    if (type.ToLower().Trim() == "locality") //if type is locality the get the locality  
                    {
                        ven.City = element.Elements().Where(e => e.Name.LocalName == "long_name").Single().Value;
                    }
                    else
                    {
                        if (type.ToLower().Trim() == "administrative_area_level_2" && string.IsNullOrEmpty(ven.City))
                        {
                            ven.City = element.Elements().Where(e => e.Name.LocalName == "long_name").Single().Value;
                        }
                    }
                    if (type.ToLower().Trim() == "administrative_area_level_1") //if type is locality the get the locality  
                    {
                        ven.State = element.Elements().Where(e => e.Name.LocalName == "long_name").Single().Value;
                    }
                    if (type.ToLower().Trim() == "country") //if type is locality the get the locality  
                    {
                        ven.Country = element.Elements().Where(e => e.Name.LocalName == "long_name").Single().Value;
                        ven.CountryCode = element.Elements().Where(e => e.Name.LocalName == "short_name").Single().Value;
                        if (ven.Country == "United States") { ven.Country = "USA"; }
                    }
                    if (type.ToLower().Trim() == "postal_code") //if type is locality the get the locality  
                    {
                        ven.ZipCode = element.Elements().Where(e => e.Name.LocalName == "long_name").Single().Value;
                    }
                }
            }
            xmlElm.RemoveAll();
            return ven;
        }

        /// <summary>  
        /// This mehthod is created to get the place details on the basis of zip code and country  
        /// </summary>  
        /// <param name="zipCode"></param>  
        /// <param name="region"></param>  
        /// <returns></returns>  
        [HttpGet, ActionName("GetVenueDetailsByZipCode")]
        public JsonResult GetVenueDetailsByZipCode(string zipCode, string region)
        {
            string geocodeApi = ConfigurationManager.AppSettings["GoogleGeocodeAPIUrl"];
            try
            {
                Venue ven = new Venue();
                geocodeApi = geocodeApi.Replace("{0}", zipCode);
                geocodeApi = geocodeApi.Replace("{1}", region);
                geocodeApi = geocodeApi.Replace("{2}", ConfigurationManager.AppSettings["GooglePlaceAPIKey"]);

                var result = new System.Net.WebClient().DownloadString(geocodeApi);

                var xmlElm = XElement.Parse(result);
                ven = GetAllVenueDetails(xmlElm);
                return Json(ven, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
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
                currentPatient.IsRxFilled = false;
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
            return View("~/Views/Home/Index.cshtml");

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
