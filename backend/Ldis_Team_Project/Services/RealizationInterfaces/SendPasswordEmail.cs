using Ldis_Team_Project.Services.Interfaces;
using Serilog;
using System.Net;
using System.Net.Mail;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class SendPasswordEmail : ISendPasswordOnEmailService
    {
        private const string SessionKeySendPassword = "PasswordKey";
        private readonly IHttpContextAccessor _ContextAccessor;
        public SendPasswordEmail(IHttpContextAccessor contextAccessor)
        {
            _ContextAccessor = contextAccessor;
        }
        public void SendPassword(string Email)
        {
            using (SmtpClient smtpClient = new SmtpClient("mtp.gmail.com", 587))
            {
                Random rand = new Random();
                string Password = Convert.ToString(rand.Next(1000000));
                _ContextAccessor.HttpContext.Session.SetString(SessionKeySendPassword, Password);
                string SenderEmail = "aspworkilla@gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SenderEmail, "fnyj cngv ehuw iwgr");
                MailMessage mailMessage = new MailMessage(SenderEmail, Email)
                {
                    Subject = "Ldis authentification password",
                    Body = $"Ваш пароль для входа в свой аккаунт Ldis {Password}, сохраните данный пароль для последуйщего входа в свой аккаунт"
                };
                try
                {
                     smtpClient.Send(mailMessage);
                }
                catch (Exception exeption)
                {
                    Log.Error($"Error send message - DateTime {DateTime.Now} error message {exeption.Message}");
                }
            }
        }
    }
}
