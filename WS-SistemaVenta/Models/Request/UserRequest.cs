namespace WS_SistemaVenta.Models.Request
{
    public class UserRequest
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
