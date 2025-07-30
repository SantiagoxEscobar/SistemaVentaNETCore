namespace WSVenta.Models.Request
{
    public class ClientRequest
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneCode { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
