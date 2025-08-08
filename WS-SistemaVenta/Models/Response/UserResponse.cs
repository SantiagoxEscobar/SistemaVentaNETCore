using System.ComponentModel.DataAnnotations;

namespace WS_SistemaVenta.Models.Response
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
