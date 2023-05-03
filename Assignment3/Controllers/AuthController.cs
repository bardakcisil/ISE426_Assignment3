using Business.Assignment3;
using Entity.Assignment3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegister userForRegister)
        {
            var userToRegister = _userService.Register(userForRegister);
            if (userToRegister)
            {
                return Ok(userToRegister);

            }

            return BadRequest("Registeration Failed");
        }



        [HttpPost("login")]
        public ActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _userService.Login(userForLogin);
            if (userToLogin == null)
            {
                return BadRequest("User not found");
            }

            return Ok(userToLogin);
        }

        [HttpPost("VulnerableRegister")]
        public ActionResult VulnerableRegister(UserForRegister userForRegister)
        {
            var userToRegister = _userService.VulnerableRegister(userForRegister);
            if (userToRegister)
            {
                return Ok(userToRegister);

            }

            return BadRequest("Registeration Failed");
        }

        [HttpPost("VulnerableLogin")]
        public ActionResult VulnerableLogin(UserForLogin userForLogin)
        {
            var userToLogin = _userService.VulnerableLogin(userForLogin);
            if (userToLogin == null)
            {
                return BadRequest("User not found");
            }

            return Ok(userToLogin);
        }
    }
}
