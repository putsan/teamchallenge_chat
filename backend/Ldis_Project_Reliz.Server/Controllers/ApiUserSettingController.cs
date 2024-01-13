using Ldis_Project_Reliz.Server.Models.BusinesModel;
using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Project_Reliz.Server.Services.Realization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ldis_Project_Reliz.Server.Controllers
{
    [ApiController]
    [Route("setting/[controller]")]
    public class ApiUserSettingController : ControllerBase
    {
        IRepository Repository;
        IClaimsAuthentificationService ClaimsAuthentification;
        ILoadUploadImageServerService LoadUploadImage;
        public ApiUserSettingController(IRepository Repository, IClaimsAuthentificationService ClaimsAuthentification, ILoadUploadImageServerService LoadUploadImage)
        {
            this.LoadUploadImage = LoadUploadImage;
            this.ClaimsAuthentification = ClaimsAuthentification;
            this.Repository = Repository;
        }
        [HttpPost("changePassword/{Password}")]
        public IActionResult ChangePassword (string Password)
        {
            string result = Repository.ChangePassword(Password);
            return Ok(result);
        }
        [HttpGet("personalUserArea")]
        public IActionResult PersonalSettingsInfo()
        {
            var User = Repository.UserInfo();
            var Avatar = LoadUploadImage.UploadImage(User.Avatar.Link);
            if (Avatar == null)
            {
                string DefaultLinkImage = "https://icons.veryicon.com/png/o/miscellaneous/rookie-official-icon-gallery/225-default-avatar.png";
            }
            UserInfoDto UserInfo = new UserInfoDto
            {
                Avatar = Avatar,
                Email = User.Enail,
                RegisteredAt = User.RegisteredAt,
                Status = User.Status,
                UserName = User.UserName,
            };
            string JsonResponce = JsonSerializer.Serialize(UserInfo);
            return Ok(JsonResponce);
        }
        [HttpPost("changeUserName/{UserName}")]
        public IActionResult ChangeUserName(string UserName)
        {
           string result = Repository.ChangeUserName(UserName);
            return Ok(result);
        }

        [HttpGet("deleteAccount")]
        public IActionResult DeleteAccount ()
        {
           string result = Repository.DeleteAccount();
            return Ok(result);
        }

        [HttpGet("logOut")]
        public IActionResult LogOut()
        {
            var User = Repository.UserInfo();
            User.IsRegidtred = false;
            Repository.SaveChanges();
            return Ok("Вы успешно вышли с аккаунта");
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
