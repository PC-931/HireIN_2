using _1.Entity_Layer;
using _2.Data_Layer.Services;
using System.Net.Http;
using System.Web.Http;

namespace _3.UI_Layer.Controllers
{
    public class AccountAPIController : ApiController
    {
        private UserDataService userDataService;
        public AccountAPIController()
        {
            userDataService = new UserDataService();
        }

        [Route("Login")]
        public IHttpActionResult Login(User usr)
        {         
            var res = userDataService.Login(usr);
            if(res!=null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("User not found");
            }            
        }
        
        [Route("Register")]
        public IHttpActionResult Register(User usr)
        {         
            var res = userDataService.Register(usr);
            if(res)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("User not found");
            }            
        }

        [Route("showUserDetails/{id}")]
        public IHttpActionResult AccountDetails(string id)
        {
            var res = userDataService.ShowDetails(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("User Details not found!!!");
            }
        }
    }
}
