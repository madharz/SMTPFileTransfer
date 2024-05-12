using SMTPFileTransfer.Models;

namespace SMTPFileTransfer.Services
{
    public class FormDataProcessingService : IFormDataProcessingService
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IEmailService _emailService;

        public FormDataProcessingService(IFileUploadService fileUploadService, IEmailService emailService)
        {
            _fileUploadService = fileUploadService;
            _emailService = emailService;
        }

        public async Task ProcessFormData(FormData formData)
        {
            // Зберігаємо файли на сервері
            var filePaths = await _fileUploadService.UploadFiles(formData.Files);

            // Підготовка та відправка електронного листа
            await _emailService.SendEmailAsync(formData, filePaths);
        }
    }
}
