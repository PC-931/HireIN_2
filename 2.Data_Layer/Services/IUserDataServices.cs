using _1.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer.Services
{
    public interface IUserDataService
    {
        User Login(User u);
        bool Register(User newUser);
    }

}
