using _1.Entity_Layer;
using _2.Data_Layer.Services;
using System.Web.Http;

namespace _3.UI_Layer.Controllers
{
    public class ApplicantAPIController : ApiController
    {
        private ApplicantDataService _applicantDataService;
        public ApplicantAPIController()
        {
            _applicantDataService = new ApplicantDataService();
        }

        [HttpGet]
        [Route("showAllApplicants")]
        public IHttpActionResult showVacancyList()
        {
            var res = _applicantDataService.ListAllApplicant();
            if (res.Count > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("No candidates applied yet");
            }
        }

        [Route("applicantAppliedToVacancy")]
        public IHttpActionResult applicantAppliedToVacancy(Applicant newAppl)
        {
            var res = _applicantDataService.CreateApplicant(newAppl);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Please retry after some time!!!");
            }
        }

        [HttpPut]
        [Route("updateAppliedCandidateStatus")]
        public IHttpActionResult updateAppliedCandidateStatus(Applicant updAppl)
        {
            var res = _applicantDataService.UpdateVacancy(updAppl);

            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Applicant status not updated! Try Again");
            }
        }

        [Route("getApplicantDetails/{id}")]
        public IHttpActionResult getApplicantDetails(int id)
        {
            Applicant vac = _applicantDataService.ShowApplicantDetails(id);
            if (vac != null)
            {
                return Ok(vac);
            }
            else
            {
                return BadRequest("Vacancy details not found!!!");
            }
        }
        [HttpDelete]
        [Route("removeApplicant/{id}")]
        public IHttpActionResult deleteVacancy(int id)
        {
            var res = _applicantDataService.DeleteApplicant(id);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Deletion failed, please try again!!!");
            }
        }
    }
}
