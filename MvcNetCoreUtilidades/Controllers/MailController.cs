using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;

namespace MvcNetCoreUtilidades.Controllers
{
    public class MailController : Controller
    {

        private IConfiguration configuration;

        public MailController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMail()
        {
            return View();
        }

   


        [HttpPost]
        public async Task<IActionResult> SendMail(string to, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();
            string user = this.configuration.GetValue<string>("MailSettings:Credentials:User");
            mail.From = new MailAddress(user);

            mail.To.Add(to);
            mail.Subject = asunto;
            mail.Body = mensaje;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            string password = this.configuration.GetValue<string>("MailSettings:Credentials:Password");
            string host = this.configuration.GetValue<string>("MailSettings:Server:Host");
            int port = this.configuration.GetValue<int>("MailSettings:Server:Port");
            bool ssl = this.configuration.GetValue<bool>("MailSettings:Server:Ssl");
            bool defaultCredentials = this.configuration.GetValue<bool>("MailSettings:Server:DefaultCredentials");

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultCredentials;

            NetworkCredential credentials = new NetworkCredential(user, password);
            await smtpClient.SendMailAsync(mail);
            ViewData["MENSAJE"] = "Mail enviado correctamente??";
            return View();

    

        }
    }
}
