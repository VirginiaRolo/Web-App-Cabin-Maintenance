using DTOs;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IUsuarioUC;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        #region ATRIBUTOS
        private IGetUsuarioUC getUnUsuarioUC { get; set; }
        private ManejadorJwt manejadorJwt { get; set; }

        private IConfiguration configMicrosoft;
        #endregion

        #region CONSTRUCTOR
        public LoginController(
            IGetUsuarioUC getUnUsuarioUC,
            ManejadorJwt manejadorJwt,

            IConfiguration configMicrosoft)
        {
            this.getUnUsuarioUC = getUnUsuarioUC;
            this.manejadorJwt = manejadorJwt;

            this.configMicrosoft = configMicrosoft;
        }
        #endregion

        /// <summary>
        /// Metodo para conseguir Token dado un usuario
        /// </summary>
        /// <param name="usuarioActual">Credenciales de usuario que desea iniciar sesion</param>
        /// <returns>Token generado</returns>
        [HttpPost("/api/Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UsuarioDto> Login([FromBody] UsuarioDto usuarioActual)
        {
            try
            {
                var usuario = ManejadorJwt.GetUsuario(usuarioActual);

                var token = ManejadorJwt.CrearToken(usuario, configMicrosoft);

                return Ok(new{Token = token, Usuario = usuario});
            }
            catch (Exception)
            {
                return Unauthorized("Datos incorrectos.");
            }
        }
    }
}
