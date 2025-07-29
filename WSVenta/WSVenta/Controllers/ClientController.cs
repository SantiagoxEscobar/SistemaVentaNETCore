using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (SistemaVentasContext db = new SistemaVentasContext())
            {
                var lst = db.Clients.ToList();
                return Ok(lst);
            }
        }
    }
}
