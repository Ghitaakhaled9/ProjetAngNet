namespace Contactly.Models
{
    public class AddRequestDTO
    {
        public required string name { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public bool favorite { get; set; }
    }
}
