namespace Contactly.Models.Domain
{
    public class Contact
    {
        public Guid id { get; set; }
        public required string name { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public bool favorite { get; set; }

    }
}
