namespace SMTPFileTransfer.Models
{
    public class FormData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Service { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public byte[] Filepound { get; set; }
    }
}
