using Microsoft.AspNetCore.Mvc;

namespace LoadImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Upload ()
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes("D:\\DotNetProject\\teamchallenge_chat\\backend\\Ldis_Project_Reliz.Server\\Images\\GargeChatAvatar.jpg");
            var resposeData = new
            {
                Message = "Hello",
                Image = Convert.ToBase64String(imageBytes)
            };
            return Ok(resposeData);

        }
    }
}
