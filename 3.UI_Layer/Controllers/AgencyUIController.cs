﻿using _1.Entity_Layer;
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

        public AgencyUIController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:63358/");
            vacList = new List<Vacancy>();
        }

        public ActionResult AgencyDashboard()
        {
            return View();
        }

        public ActionResult ShowVacancy() 
        {
            //try
            //{
            //    var res = _httpClient.GetAsync("showAllVacancies").Result;
            //    if (res.IsSuccessStatusCode)
            //    {
            //        var q = res.Content.ReadAsAsync<List<Vacancy>>().Result;
            //        vacList = q.ToList();
            //        if (vacList.Count > 0)
            //        {
            //            return View(vacList);
            //        }
            //        else
            //        {
            //            TempData["err"] = "Please first create vacancy to view";
            //            return View(vacList);
            //        }
            //    }
            //    else
            //    {
            //        TempData["err"] = $"Error: {res.StatusCode} - {res.ReasonPhrase}";
            //    }
            //}
            //catch(Exception ex)
            //{
            //    TempData["err"] = ex.Message;
            //}

            try
            {
                string agentId = (string)Session["aid"];

                var res = _httpClient.GetAsync("showAllVacancies").Result;
                if (res.IsSuccessStatusCode)
                {
                    vacList = res.Content.ReadAsAsync<List<Vacancy>>().Result;

                    var q = from vac in vacList
                            where vac.AgencyId == agentId
                            select vac;

                    return View(q);
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
    }
}