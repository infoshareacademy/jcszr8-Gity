using System.Text;
using CarRental.Logic.MailConf;
using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

public class EmailService : IEmailService
{
    private readonly MailSettings _settings;
    private readonly ILogger<MailSettings> _logger;
    private readonly IReportService _reportService;

    public EmailService(IOptions<MailSettings> settings, ILogger<MailSettings> logger, IReportService reportService)
    {
        _settings = settings.Value;
        _logger = logger;
        _reportService = reportService;
    }


    public async Task SendEmailToAdmin()
    {
        var reportToSend = await _reportService.GetDailyReport();
        var report = reportToSend;

        if (reportToSend != null)
        {
            var emailBody = new StringBuilder();

            emailBody.AppendLine("Last Logged");
            foreach (var think in reportToSend.LastLoggedReports)
            {
                emailBody.AppendLine(" ");
                emailBody.AppendLine($"User ID from Last Logged: {think.UserId} ");
                emailBody.AppendLine($"Last Logged: {think.LastLogged}");
            }
            
            emailBody.AppendLine(" ");
            emailBody.AppendLine("VISITED CARS");
            foreach (var car in reportToSend.VisitedCars)
            {
                emailBody.AppendLine(" ");
                emailBody.AppendLine($"User ID from Visited Cars: {car.UserId}");
                emailBody.AppendLine($"Car ID: {car.CarId} ");
                emailBody.AppendLine($"Date When Clicked: {car.DateWhenClicked}");
                emailBody.AppendLine($"Make: {car.Make}");
                emailBody.AppendLine($"Model: {car.Model}");
                emailBody.AppendLine($"Year: {car.Year}");
                emailBody.AppendLine($"Licence Plate: {car.LicencePlate}");
            }

            var mailData = new EmailData(
            new List<string> { "patrykwiacek00@gmail.com" },
            "Daily Report",
            emailBody.ToString(),
            null,
            "System Admin",
            null,
            "Test mail"
        );

            await SendAsync(mailData, new CancellationToken());
        }
    }
    public async Task<bool> SendAsync(EmailData mailData, CancellationToken ct = default)
    {
        try
        {
            // Initialize a new instance of the MimeKit.MimeMessage class
            var mail = new MimeMessage();

            #region Sender / Receiver

            // Sender
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName,
                mailData.From ?? _settings.From);

            // Receiver
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // Set Reply to if specified in mail data
            if (!string.IsNullOrEmpty(mailData.ReplyTo))
                mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

            // BCC
            // Check if a BCC was supplied in the request
            if (mailData.Bcc != null)
            {
                // Get only addresses where value is not null or with whitespace. x = value of address
                foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }

            // CC
            // Check if a CC address was supplied in the request
            if (mailData.Cc != null)
            {
                foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }

            #endregion Sender / Receiver

            #region Content

            // Add Content to Mime Message
            string formattedBody = mailData.Body.Replace(Environment.NewLine, "<br>");
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;
            body.HtmlBody = formattedBody;
            mail.Body = body.ToMessageBody();

            #endregion Content

            #region Send Mail

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            if (_settings.UseSSL)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
            }
            else if (_settings.UseStartTls)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
            }

            await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
            await smtp.SendAsync(mail, ct);
            await smtp.DisconnectAsync(true, ct);

            #endregion Send Mail

            _logger.LogInformation("Email succefully sended");
            return true;
        }
        catch (Exception)
        {
            _logger.LogError("Problem with email send");
            return false;
        }
    }

}
