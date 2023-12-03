using _1.Entity_Layer;
using _2.Data_Layer.Services;
using System.Web.Http;

namespace _3.UI_Layer.Controllers
{
    public class AgencyAPIController : ApiController
    {

        private VacancyDataService _vacancyDataService;

        public AgencyAPIController()
        {
            _vacancyDataService = new VacancyDataService();
        }

        [Route("showAllVacancies")]
        public IHttpActionResult showVacancyList()
        {
            var res = _vacancyDataService.ListAllVacancy();
            if(res.Count > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("No vacancy posted yet");
            }
        }

        [Route("newVacancy")]
        public IHttpActionResult createVacancy( Vacancy newVac )
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

    }
}
