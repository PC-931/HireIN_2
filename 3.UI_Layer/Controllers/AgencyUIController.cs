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

        public AgencyUIController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:63358/");
            vacList = new List<Vacancy>();
            vac = new Vacancy();
            applList = new List<Applicant>();
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
                vac = res.Content.ReadAsAsync<Vacancy>().Result;
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
                vac = res.Content.ReadAsAsync<Vacancy>().Result;
                if (vac != null)
                {
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
                return RedirectToAction("showVacancy");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "accountui");
        }

        public ActionResult ShowApplicantsApplied()
        {
            var res = _httpClient.GetAsync("ShowApplicants").Result;
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
    }
}