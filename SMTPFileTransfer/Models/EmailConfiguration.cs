namespace SMTPFileTransfer.Models
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }
}
