using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using CarRental.Web.Models;

namespace CarRental.Web.Controllers
{
    public class EmailDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailData emailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailData.From));
            email.To.Add(MailboxAddress.Parse(emailData.To));
            email.Subject = emailData.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailData.Body };

            using var smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(emailData.From, emailData.Password);
            smtp.Send(email);
            smtp.Disconnect(true);


            return RedirectToAction("SentEmail");
        }
        public IActionResult SentEmail()
        {
            ViewData["Success"] = "Email has been sent successfully!";
            return View();
        }
    }
}
