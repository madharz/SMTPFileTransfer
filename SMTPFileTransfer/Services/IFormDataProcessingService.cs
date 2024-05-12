using SMTPFileTransfer.Models;

namespace SMTPFileTransfer.Services
{
    public interface IFormDataProcessingService
    {
        Task ProcessFormData(FormData formData);
    }
}
