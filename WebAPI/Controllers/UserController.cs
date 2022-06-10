using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UserController : ControllerBase
    { 

        private IUser _userService = new UserService();


        [HttpGet]
        [Route("GetUser")]
        public bool GetUser(string username, string password)
        {
            return _userService.VerifyUser(username, password);

        }
        [HttpGet]
        [Route("RegisterUser")]
        public JsonResult RegisterUser(string lastName, string firstName,string username, string password)
        {
           var result = _userService.RegisterUser(lastName, firstName,username, password);
           return new JsonResult(result);
        }
    }
}