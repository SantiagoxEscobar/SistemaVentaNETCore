using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.Request;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    var lst = db.Clients.ToList();
                    oReply.Success = 1;
                    oReply.Data = lst;
                }
            }
            catch (Exception ex)
            {

                oReply.Message = ex.Message;
            }

            return Ok(oReply);
        }

        [HttpPost]
        public IActionResult Add(ClientRequest oModel)
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    Client oClient = new Client();
                    oClient.IdUser = oModel.IdUser;
                    oClient.FirstName = oModel.FirstName;
                    oClient.LastName = oModel.LastName;
                    oClient.Email = oModel.Email;
                    oClient.PhoneCode = oModel.PhoneCode;
                    oClient.PhoneNumber = oModel.PhoneNumber;
                    oClient.BirthDate = oModel.BirthDate;
                    oClient.DocumentType = oModel.DocumentType;
                    oClient.DocumentNumber = oModel.DocumentNumber;
                    //Usar automapper o mapeo acá arriba

                    db.Clients.Add(oClient);
                    db.SaveChanges();
                    oReply.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oReply.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return Ok(oReply);
        }
    }
}
