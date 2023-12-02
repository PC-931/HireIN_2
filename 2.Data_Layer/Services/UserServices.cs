using _1.Entity_Layer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace _2.Data_Layer.Services
{
    public class UserServices : Repo.IUser
    {
        private AppDbContext _appDbContext;
        private UserManager<User> userManager;
        private UserStore<User> userStore;

        public UserServices()
        {
            _appDbContext = new AppDbContext();
            userStore = new UserStore<User>(_appDbContext);
            userManager = new UserManager<User>(userStore);
        }

        public bool Create(User newUser)
        {
            IdentityResult res = userManager.Create(newUser, newUser.Password);
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(User usr)
        {
            IdentityResult res = userManager.Delete(usr);
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Read(string email, string pass)
        {
            var user = userManager.FindByEmail(email);
            if (user != null && userManager.CheckPassword(user, pass))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> ReadAll()
        {
            List<User> users = new List<User>();
            users = _appDbContext.Users.ToList();

            return users;
        }

        public bool Update(User updUser)
        {
            User user = _appDbContext.Users.Find(updUser.Id);
            if (user != null)
            {
                userManager.Update(updUser);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
