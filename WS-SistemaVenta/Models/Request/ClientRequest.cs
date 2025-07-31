namespace WS_SistemaVenta.Models.Request
{
    public class ClientRequest
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneCode { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
