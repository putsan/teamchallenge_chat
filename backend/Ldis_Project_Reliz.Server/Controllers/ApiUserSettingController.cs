using Microsoft.AspNetCore.Mvc;

namespace Ldis_Project_Reliz.Server.Controllers
{
    [ApiController]
    [Route("setting/[controller]")]
    public class ApiUserSettingController : ControllerBase
    {
        [HttpPost("changePassword/{Password}")]
        public IActionResult ChangePassword (string Password)
        {
            return Ok();
        }

        [HttpPost("changeUserName/{UserName}")]
        public IActionResult ChangeUserName(string UserName)
        {
            return Ok();
        }

        [HttpGet("deleteAccount")]
        public IActionResult DeleteAccount ()
        {
            return Ok();
        }

        [HttpGet("logOut")]
        public IActionResult LogOut()
        {
            return Ok();
        }

        [HttpPost("changeProfileImage")]
        public IActionResult ChangeProfileImage()
        {
            return Ok();
        }
    }
}
