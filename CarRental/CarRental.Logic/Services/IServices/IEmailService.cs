using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services.IServices;
public interface IEmailService
{
    Task SendEmailToAdmin();
}
