using WS_SistemaVenta.Models.Request;
using WS_SistemaVenta.Models.Response;

namespace WS_SistemaVenta.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
