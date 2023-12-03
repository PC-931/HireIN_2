using _1.Entity_Layer;
using _2.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _3.UI_Layer.Controllers
{
    public class AccountUIController : Controller
    {

        private AppDbContext db;
        private HttpClient client;

        public AccountUIController()
        {
            db = new AppDbContext();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63358/");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( User u )
        {
            var res = client.PostAsJsonAsync<User>("Login", u).Result;
            if (res.IsSuccessStatusCode)
            {
                User data = res.Content.ReadAsAsync<User>().Result;
                Session["uid"] = data.Id;
                if (data.Role.ToLower() == "agency")
                {
                    return RedirectToAction("AgencyDashboard", "AgencyUI" , data);
                }
                else
                {
                    return RedirectToAction("CandidateDashboard", "CandidateUI" ,data);
                }
            }
            else
            {
                TempData["err"] = "User not found";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            var res = client.PostAsJsonAsync<User>("Register", u).Result;

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            else
            {
                TempData["err"] = "Some error occured";
                return View();
            }
        }
    }
}