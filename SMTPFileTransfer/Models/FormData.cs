namespace SMTPFileTransfer.Models
{
    public class FormData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Service { get; set; }
        public DateTime ChooseDate { get; set; }
        public string DetailedInformation { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
