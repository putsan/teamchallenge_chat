using Ldis_Team_Project.Services.Interfaces;
using Serilog;
using System.Net;
using System.Net.Mail;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class SendCodeAuth : ISendCodeAuthService
    {
        private readonly IHttpContextAccessor _ContextAccessor;
        public SendCodeAuth(IHttpContextAccessor contextAccessor)
        {
            _ContextAccessor = contextAccessor;
        }
        public void SendCode(string Email)
        {
            var ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<SendCodeAuth>().Build();
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587))
            {
                Random rand = new Random();
                string Code = Convert.ToString(rand.Next(1000000));
                _ContextAccessor.HttpContext.Session.SetString("CodeKey",Code);
                string Sender = ConfigurationFile.GetValue<string>("CodeVerification:SenderEmail");
                string AppPassword = ConfigurationFile.GetValue<string>("CodeVerification:AppPassword");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Sender,AppPassword);
                MailMessage message = new MailMessage(Sender, Email)
                {
                    Subject = "Ldis authentification password",
                    Body = $"Ваш пароль для входа в свой аккаунт Ldis {Code}, сохраните данный пароль для последуйщего входа в свой аккаунт"
                };
                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception exeption)
                {
                    Log.Error($"Error send message - DateTime {DateTime.Now} error message {exeption.Message}");
                }

            }
        }
    }
}
