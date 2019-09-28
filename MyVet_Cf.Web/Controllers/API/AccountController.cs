using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyVet_Cf.Common.Models;
using MyVet_Cf.Web.Data;
using MyVet_Cf.Web.Data.Entities;
using MyVet_Cf.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet_Cf.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;

        public AccountController(
            DataContext dataContext,
            IUserHelper userHelper,
            IMailHelper mailHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<object>
                {
                    IsSuccess = false,
                    Message = "Solicitud incorrecta"
                });
            }

            var user = await _userHelper.GetUserByEmailAsync(request.Email);
            if (user != null)
            {
                return BadRequest(new Response<object>
                {
                    IsSuccess = false,
                    Message = "Este Correo ya esta registrado"
                });
            }

            user = new User
            {
                Address = request.Address,
                Document = request.Document,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.Phone,
                UserName = request.Email
            };

            var result = await _userHelper.AddUserAsync(user, request.Password);
            if (result != IdentityResult.Success)
            {
                return BadRequest(result.Errors.FirstOrDefault().Description);
            }


            var userNew = await _userHelper.GetUserByEmailAsync(request.Email);
            await _userHelper.AddUserToRoleAsync(userNew, "Customer");
            _dataContext.Owners.Add(new Owner { User = userNew });
            await _dataContext.SaveChangesAsync();

            var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
            var tokenLink = Url.Action("ConfirmEmail", "Account", new
            {
                userid = user.Id,
                token = myToken
            }, protocol: HttpContext.Request.Scheme);

            _mailHelper.SendMail(request.Email, "Confirmación de Correo", $"<h1>Confirmación de correo</h1>" +
                $"Para permitir al Usuario, " +
                $"por favor haga clic en este enlace:</br></br><a href = \"{tokenLink}\">Confirmar Correo</a>");

            return Ok(new Response<object>
            {
                IsSuccess = true,
                Message = "Se envió un correo electrónico de confirmación. Confirme su cuenta e inicie sesión en la aplicación."
            });
        }

        //----------------------------------------------------

        [HttpPost]
        [Route("RecoverPassword")]
        public async Task<IActionResult> RecoverPassword([FromBody] EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<object>
                {
                    IsSuccess = false,
                    Message = "Bad request"
                });
            }

            var user = await _userHelper.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest(new Response<object>
                {
                    IsSuccess = false,
                    Message = "Este correo no ha sido asignado a ningún Usuario"
                });
            }

            var myToken = await _userHelper.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token = myToken }, protocol: HttpContext.Request.Scheme);
            _mailHelper.SendMail(request.Email, "Restablecimiento de contraseña", $"<h1>Recuperar contraseña</h1>" +
                $"Para restablecer la contraseña, haga clic en este enlace:</br></br>" +
                $"<a href = \"{link}\">Restablecer Contraseña</a>");

            return Ok(new Response<object>
            {
                IsSuccess = true,
                Message = "Se envió un correo electrónico con instrucciones para cambiar la contraseña."
            });
        }

        //-------------------------------------------------------------------

        [HttpPut]//metodo para modificar
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userEntity = await _userHelper.GetUserByEmailAsync(request.Email);
            if (userEntity == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            userEntity.FirstName = request.FirstName;
            userEntity.LastName = request.LastName;
            userEntity.Address = request.Address;
            userEntity.PhoneNumber = request.Phone;
            userEntity.Document = request.Phone;

            var respose = await _userHelper.UpdateUserAsync(userEntity);
            if (!respose.Succeeded)
            {
                return BadRequest(respose.Errors.FirstOrDefault().Description);
            }

            var updatedUser = await _userHelper.GetUserByEmailAsync(request.Email);
            return Ok(updatedUser);
        }

    }
}
