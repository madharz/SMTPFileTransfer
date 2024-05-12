namespace SMTPFileTransfer.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<string[]> UploadFiles(IFormFileCollection files)
        {
            List<string> filePaths = new List<string>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    filePaths.Add(filePath);
                }
            }

            return filePaths.ToArray();
        }
    }
}
