using Ldis_Project_Reliz.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ldis_Project_Reliz.Server.Controllers
{
    [ApiController]
    [Route("setting/[controller]")]
    public class ApiUserSettingController : ControllerBase
    {
        IRepository Repository;
        public ApiUserSettingController(IRepository Repository)
        {
            this.Repository = Repository;
        }
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
            var file = HttpContext.Request.Form.Files["image"];
            Repository.UptadeUserAvatar(file);
            return Ok();
        }
    }
} 
