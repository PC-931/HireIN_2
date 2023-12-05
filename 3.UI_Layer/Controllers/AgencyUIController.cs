using _1.Entity_Layer;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _3.UI_Layer.Controllers
{
    public class AgencyUIController : Controller
    {
        private HttpClient _httpClient;
        private List<Vacancy> vacList;
        private Vacancy vac;
        private List<Applicant> applList;
        private Applicant appl;

        public AgencyUIController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:63358/");
            vacList = new List<Vacancy>();
            vac = new Vacancy();
            applList = new List<Applicant>();
            appl = new Applicant();
        }

        public ActionResult AgencyDashboard()
        {
            return View();
        }

        public ActionResult ShowVacancy() 
        {            
            try
            {
                var res = _httpClient.GetAsync("showAllVacancies").Result;
                if (res.IsSuccessStatusCode)
                {
                    vacList = res.Content.ReadAsAsync<List<Vacancy>>().Result;

                    //var q = from v in vacList
                    //        where v.AgencyId == vac.AgencyId
                    //        select v;

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


        [HttpGet]
        public ActionResult createVacancy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createVacancy( Vacancy newVac )
        {
            newVac.AgencyId = (string)Session["uid"];
            var res = _httpClient.PostAsJsonAsync<Vacancy>("newVacancy", newVac).Result;
            
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowVacancy");
            }
            else
            {
                TempData["err"] = "some error occured";
                return View();
            }
        }

        [HttpGet]
        public ActionResult editVacancy(int id)
        {
            var res = _httpClient.GetAsync("getVacancy/" + id).Result;
            vac = res.Content.ReadAsAsync<Vacancy>().Result;
            return View(vac);
        }

        [HttpPost]
        public ActionResult editVacancy(Vacancy updVac)
        {
            var res = _httpClient.PutAsJsonAsync<Vacancy>("updateVacancyDetails", updVac).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowVacancy");
            }
            else
            {
                TempData["err"] = "Some error occured! Please try again";
                return View();
            }
        }


        public ActionResult showVacancyById( int id )
        {
            try
            {
                var res = _httpClient.GetAsync("getVacancy/"+ id).Result;
                if (res.IsSuccessStatusCode)
                {
                    vac = res.Content.ReadAsAsync<Vacancy>().Result;
                    return View(vac);
                }
                else
                {
                    TempData["err"] = "record not found!!!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult deleteVacancyById( int id )
        {
            var res = _httpClient.DeleteAsync("removeVacancy/" + id).Result;
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("showvacancy");
            }
            else
            {
                TempData["err"] = "Delettion unsuccessful";
                return RedirectToAction("showVacancy");
            }
        }

        public ActionResult ShowApplicantsApplied()
        {
            var res = _httpClient.GetAsync("showAllApplicants").Result;
            if (res.IsSuccessStatusCode)
            {
                applList = res.Content.ReadAsAsync<List<Applicant>>().Result;
                return View(applList);
            }
            else
            {
                TempData["err"] = "No applicant to display";
                return View();
            }
        }

        public ActionResult CandateAccepted(int id)
        {
            var res = _httpClient.GetAsync("getApplicantDetails/"+id).Result;
            if (res.IsSuccessStatusCode)
            {
                appl = res.Content.ReadAsAsync<Applicant>().Result;
                appl.Status = "Accepted";

                var sendData = _httpClient.PutAsJsonAsync<Applicant>("updateAppliedCandidateStatus", appl).Result;
                if(sendData.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowApplicantsApplied");
                }
                else
                {
                    TempData["err"] = "Failed to accept candidate try again!";
                    return RedirectToAction("ShowApplicantsApplied");
                }
            }
            else
            {
                TempData["err"] = "Applicant isn't found";
                return RedirectToAction("ShowApplicantsApplied");
            }
        }

        public ActionResult CandateRejected(int id)
        {
            var res = _httpClient.GetAsync("getApplicantDetails/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                appl = res.Content.ReadAsAsync<Applicant>().Result;
                appl.Status = "Rejected";

                var sendData = _httpClient.PutAsJsonAsync<Applicant>("updateAppliedCandidateStatus", appl).Result;
                if (sendData.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowApplicantsApplied");
                }
                else
                {
                    TempData["err"] = "Failed to accept candidate try again!";
                    return RedirectToAction("ShowApplicantsApplied");
                }
            }
            else
            {
                TempData["err"] = "Applicant isn't found";
                return RedirectToAction("ShowApplicantsApplied");
            }
        }
    }
}