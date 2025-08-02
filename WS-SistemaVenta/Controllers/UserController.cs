using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_SistemaVenta.Models;
using WS_SistemaVenta.Models.Request;
using WS_SistemaVenta.Models.Response;

namespace WS_SistemaVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    var lst = db.Users.OrderByDescending(d => d.Id).ToList();
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
        public IActionResult AddUser(UserRequest oModel)
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    User oUser = new User();
                    oUser.IdRole = oModel.IdRole;
                    oUser.Username = oModel.Username;
                    oUser.PasswordHash = oModel.PasswordHash;
                    oUser.Salt = oModel.Salt;
                    oUser.Email = oModel.Email;

                    db.Users.Add(oUser);
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
        public IActionResult UpdateUser(UserRequest oModel)
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    User oUser = db.Users.Find(oModel.Id);
                    if (oUser == null)
                    {
                        oReply.success = 0;
                        oReply.message = "User not found";
                        return NotFound(oReply);
                    }
                    oUser.IdRole = oModel.IdRole;
                    oUser.Username = oModel.Username;
                    oUser.PasswordHash = oModel.PasswordHash;
                    oUser.Salt = oModel.Salt;
                    oUser.Email = oModel.Email;

                    db.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            Reply oReply = new Reply();
            try
            {
                using (SistemaVentasContext db = new SistemaVentasContext())
                {
                    User oUser = db.Users.Find(id);
                    if (oUser == null)
                    {
                        oReply.success = 0;
                        oReply.message = "User not found";
                        return NotFound(oReply);
                    }
                    db.Users.Remove(oUser);
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
