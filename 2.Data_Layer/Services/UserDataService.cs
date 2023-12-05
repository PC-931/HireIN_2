using _1.Entity_Layer;

namespace _2.Data_Layer.Services
{
    public class UserDataService : IUserDataService
    {
        private UserServices userServices;

        public UserDataService()
        {
            userServices = new UserServices();
        }

        public User Login(User u)
        {
            User user = userServices.Read(u.Email, u.Password);
            return user;
        }

        public bool Register(User newUser)
        {
            if (userServices.Create(newUser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User ShowDetails(string id)
        {
            User u = userServices.ReadById(id);
            return u;
        }

    }
}
