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

            return RedirectToAction("SentEmail");
        }
        public IActionResult SentEmail()
        {
            ViewData["Success"] = "Email has been sent successfully!";
            return View();
        }
    }
}
