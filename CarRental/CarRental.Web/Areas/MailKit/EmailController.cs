using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CarRental.Web.Areas.MailKit;
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    [HttpPost]
    public IActionResult SendEmail(string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("team-gity@o2.pl"));
        email.To.Add(MailboxAddress.Parse("jacekpardel@gmail.com"));
        email.Subject = "Daily report";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("team-gity@tlen.pl", "jcszr8-gity");
        smtp.Send(email);
        smtp.Disconnect(true);
        return Ok();

    }
}
