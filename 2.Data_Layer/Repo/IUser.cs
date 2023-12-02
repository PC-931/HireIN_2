using _1.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer.Repo
{
    public interface IUser
    {
        List<User> ReadAll();
        User Read(string email, string pass);
        bool Create(User newUser);
        bool Update(User updUser);
        bool Delete(User usr);
    }

}
