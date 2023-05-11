using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeMessage


namespace CarRental.Web.Areas.MailKit;
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    [HttpPost]
    public IActionResult SendEmail(string body)
    {
        var email = new MimeMessage();

    }
}
