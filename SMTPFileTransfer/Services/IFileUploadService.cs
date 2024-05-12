namespace SMTPFileTransfer.Services
{
    public interface IFileUploadService
    {
        Task<string[]> UploadFiles(IFormFileCollection files);
    }
}
