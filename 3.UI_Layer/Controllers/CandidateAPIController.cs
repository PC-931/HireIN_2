using _1.Entity_Layer;
using _2.Data_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace _3.UI_Layer.Controllers
{
    public class CandidateAPIController : ApiController
    {
        private VacancyDataService _vacancyDataService;
        private ApplicantDataService _applicantDataService;

        public CandidateAPIController()
        {
            _vacancyDataService = new VacancyDataService();
            _applicantDataService = new ApplicantDataService();
        }

        //[Route("viewAllVacancies")]
        //public IHttpActionResult ShowAllVacancy()
        //{
        //    var res = _vacancyDataService.ListAllVacancy();
        //    if (res.Count > 0)
        //    {
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest("No vacancy posted yet");
        //    }
        //}

        //[Route("ApplyVacancy")]
        //public IHttpActionResult AppliedCandidate(Applicant appl)
        //{                        
        //    var res = _applicantDataService.CreateApplicant(appl);
        //    if (res)
        //        return Ok();
        //    else
        //        return BadRequest();
        //}

        //[Route("ShowApplicants")]
        //public IHttpActionResult ApplcationDetails()
        //{
        //    var res = _applicantDataService.ListAllApplicant();
        //    return Ok(res);
        //}
    }
}
