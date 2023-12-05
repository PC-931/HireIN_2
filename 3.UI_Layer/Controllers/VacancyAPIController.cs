using _1.Entity_Layer;
using _2.Data_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3.UI_Layer.Controllers
{
    public class VacancyAPIController : ApiController
    {
        private VacancyDataService _vacancyDataService;
        public VacancyAPIController()
        {
            _vacancyDataService = new VacancyDataService();
        }

        [HttpGet]
        [Route("showAllVacancies")]
        public IHttpActionResult showVacancyList()
        {
            var res = _vacancyDataService.ListAllVacancy();
            if (res.Count > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("No vacancy posted yet");
            }
        }

        [Route("newVacancy")]
        public IHttpActionResult createVacancy(Vacancy newVac)
        {
            var res = _vacancyDataService.CreateVacancy(newVac);
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
        [Route("updateVacancyDetails")]
        public IHttpActionResult editVacancy(Vacancy updVac)
        {
            var res = _vacancyDataService.UpdateVacancy(updVac);

            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Data not updated");
            }
        }

        [Route("getVacancy/{id}")]
        public IHttpActionResult getVacancyDetails(int id)
        {
            Vacancy vac = _vacancyDataService.ShowVacancyDetails(id);
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
        [Route("removeVacancy/{id}")]
        public IHttpActionResult deleteVacancy(int id)
        {
            var res = _vacancyDataService.DeleteVacancy(id);
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
