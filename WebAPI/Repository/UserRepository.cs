using System.Linq;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class UserRepository
    {
        private Context _context;
        public UserRepository()
        {
            _context = new Context();
        }
        public bool VerifyUser(string username, string password)
        {
            var result =  _context.Users.Any(u => u.Username == username && u.Password == password);
            return result;
        }
        public void RegisterUser(string lastName, string firstName, string username, string password)

        {
            var user = new User() { FirstName = firstName, LastName = lastName, Username = username, Password = password };

            _context.Users.Add(user);
            _context.SaveChanges();
           
        }
         public bool VerifyIfUserExits(string lastName, string firstName, string username, string password)
        {
            var result = _context.Users.Any(u => u.Username == username );
            return result;
        }


    }
   
}
