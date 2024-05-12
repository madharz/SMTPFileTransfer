using SMTPFileTransfer.Models;

namespace SMTPFileTransfer.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(FormData formData, string[] filePaths);
    }
}
