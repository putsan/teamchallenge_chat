﻿using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ldis_Project_Reliz.Server.Controllers
{

    [ApiController]
    [Route("main/[controller]")]
    public class ApiMainController : ControllerBase
    {
        IRepository Repository;
        ILoadUploadImageServerService LoadImage;
        public ApiMainController(IRepository Repository, ILoadUploadImageServerService LoadImage)
        {
            this.LoadImage = LoadImage;
            this.Repository = Repository;
        }
        [HttpGet("getRandomChat")]
        public IActionResult GetRandomChat()
        {
            var Chat = Repository.RandomChat();
            string responce = JsonSerializer.Serialize(Chat);
            return Ok(responce);
        }

        [HttpGet("getAllChats")]
        public IActionResult GetAllChats()
        {
            return Ok();
        }

        [HttpPost("getChat/{ChatName}")]
        public IActionResult GetChat (string ChatName)
        {
            var Chats = Repository.FindChat(ChatName);
            var Responce = JsonSerializer.Serialize(Chats);
            return Ok(Responce);
        }
        [HttpGet]

        [HttpPost("createChat/{ChatName},{CountUsers},{AutoDelete},{ChatGenre},{Describing},{Visible}")]
        public IActionResult CreateChat (string ChatName,
            int CountUsers,
            bool AutoDelete,
            string ChatGenre,
            string Describing,string Visible)
        {
            var file = HttpContext.Request.Form.Files["image"];
            Repository.CreateNewGroup(ChatName,Describing,CountUsers,AutoDelete,ChatGenre,Visible,file);
            return Ok();
        }
        [HttpPost("deleteGroup/{Id}")]
        public IActionResult DeleteGroup(int Id)
        {
            string result = Repository.DeleteGroup(Id);
            return Ok(result);
        }
    }
}
