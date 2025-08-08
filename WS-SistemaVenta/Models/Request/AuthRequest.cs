using System.ComponentModel.DataAnnotations;

namespace WS_SistemaVenta.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
