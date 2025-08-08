using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WS_SistemaVenta.Models;
using WS_SistemaVenta.Models.Request;
using WS_SistemaVenta.Models.Response;

namespace WS_SistemaVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClients()
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    var lst = db.Clients.OrderByDescending(d=>d.Id).ToList();
                    oReply.success = 1;
                    oReply.data = lst;
                }
            }
            catch (Exception ex)
            {
                oReply.success = 0;
                oReply.message = ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : "");
            }
            return Ok(oReply);
        }

        [HttpPost]
        public IActionResult AddClient(ClientRequest oModel)
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

                    db.Clients.Add(oClient);
                    db.SaveChanges();

                    oReply.success = 1;
                }
            }
            catch (Exception ex)
            {
                oReply.success = 0;
                oReply.message = ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : "");
            }
            return Ok(oReply);
        }

        [HttpPut]
        public IActionResult UpdateClient(ClientRequest oModel)
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    Client oClient = db.Clients.Find(oModel.Id);
                    if (oClient == null)
                    {
                        oReply.success = 0;
                        oReply.message = "Client not found.";
                        return NotFound(oReply);
                    }
                    oClient.IdUser = oModel.IdUser;
                    oClient.FirstName = oModel.FirstName;
                    oClient.LastName = oModel.LastName;
                    oClient.Email = oModel.Email;
                    oClient.PhoneCode = oModel.PhoneCode;
                    oClient.PhoneNumber = oModel.PhoneNumber;
                    oClient.BirthDate = oModel.BirthDate;
                    oClient.DocumentType = oModel.DocumentType;
                    oClient.DocumentNumber = oModel.DocumentNumber;

                    db.Entry(oClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oReply.success = 1;
                }
            }
            catch (Exception ex)
            {
                oReply.success = 0;
                oReply.message = ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : "");
            }
            return Ok(oReply);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteClient(int Id)
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    Client oClient = db.Clients.Find(Id);
                    if (oClient == null)
                    {
                        oReply.success = 0;
                        oReply.message = "Client not found.";
                        return NotFound(oReply);
                    }
                    db.Remove(oClient);
                    db.SaveChanges();

                    oReply.success = 1;
                }
            }
            catch (Exception ex)
            {
                oReply.success = 0;
                oReply.message = ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : "");
            }
            return Ok(oReply);
        }
    }
}
