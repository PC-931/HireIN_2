using _1.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace _3.UI_Layer.Controllers
{
    public class CandidateUIController : Controller
    {
        private HttpClient _httpClient;
        private List<Vacancy> vacList;
        private List<Applicant> applList;
        private Vacancy vac;

        public CandidateUIController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:63358/");
            vacList = new List<Vacancy>();
            vac = new Vacancy();
        }

        public ActionResult CandidateDashboard( User u)
        {
            return View();
        }

        public ActionResult showVacancyToCandidate()
        {
            try
            {
                var res = _httpClient.GetAsync("showAllVacancies").Result;
                if (res.IsSuccessStatusCode)
                {
                    vacList = res.Content.ReadAsAsync<List<Vacancy>>().Result;                  
                    return View(vacList);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult CandidateApplied(int vid)
        {
            Applicant appl = new Applicant();
            appl.Status = "Applied";
            appl.CandidateId = (string)Session["uid"];
            appl.VacancyId = vid;

            var res = _httpClient.PostAsJsonAsync<Applicant>("applicantAppliedToVacancy", appl).Result;
            if(res.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                TempData["err"] = "Some error occured! Try again";
                return RedirectToAction("showVacancyToCandidate");
            }
        }

        public ActionResult vacancyDetails(int vid)
        {
            var res = _httpClient.GetAsync("getVacancy/" + vid).Result;
            if (res.IsSuccessStatusCode)
            {
                vac = res.Content.ReadAsAsync<Vacancy>().Result;
                return View(vac);
            }
            else
            {
                TempData["err"] = "vacancy details isn't available";
                return View();
            }

        }

        public ActionResult AppliedApplicantStatus()
        {
            var res = _httpClient.GetAsync("showAllApplicants").Result;
            if (res.IsSuccessStatusCode)
            {
                applList = res.Content.ReadAsAsync<List<Applicant>>().Result;
                return View(applList);
            }
            else
            {
                TempData["err"] = "Some error occured";
                return RedirectToAction("CandidateDashboard");
            }
        }
              
    }
}