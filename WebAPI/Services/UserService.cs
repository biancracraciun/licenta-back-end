using WebAPI.Interfaces;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class UserService : IUser

    {
        private readonly UserRepository userRepository = new UserRepository();

        public string RegisterUser(string lastName, string firstName, string username, string password)
        {
             string result;
            if( userRepository.VerifyIfUserExits( lastName,  firstName, username,password))
            {
                result = "Acest user exista deja";
            }
            else
            {
                userRepository.RegisterUser(lastName, firstName, username, password);
                result = "User creat cu succes";
            }
           
            return result;
        }

        public bool VerifyUser(string username, string password)
        {
            return userRepository.VerifyUser(username, password);

        }
    

    }
}
