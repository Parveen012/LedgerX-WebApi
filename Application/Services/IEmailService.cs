using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IEmailService
    {
        Task SendEmail(string email,string subject, string message);
    }
}
