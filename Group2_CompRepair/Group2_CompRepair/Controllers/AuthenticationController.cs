using Microsoft.AspNetCore.Mvc;

namespace Group2_CompRepair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;

        public AuthenticationController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpPost]
        public IActionResult AuthUser([FromBody] User user)
        {
            var token = jwtAuthenticationManager.Authentication(user.username, user.password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
