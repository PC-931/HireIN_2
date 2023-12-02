using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Entity_Layer
{
    public class User : IdentityUser
    {
        public string Password {  get; set; }
        public string Role { get; set; }
    }
}
