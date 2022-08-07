using AdvAnalyzer.WebApi.Models;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Services
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message);
        Task SendEmailAsync(EmailMessage message);

    }
}
