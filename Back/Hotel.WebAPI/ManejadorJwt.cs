using DTOs;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IUsuarioUC;
using Hotel.LogicaNegocio.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Hotel.WebAPI
{
    public class ManejadorJwt
    {
        private static IGetUsuarioUC _getUsuario { get; set; }

        public ManejadorJwt(IGetUsuarioUC getUsuario)
        {
            _getUsuario = getUsuario;
        }

        public static UsuarioDto GetUsuario(UsuarioDto nombreUsuario)
        {
            UsuarioDto retorno = _getUsuario.GetUsuario(nombreUsuario);

            return retorno;
        }

        public static string CrearToken(UsuarioDto usuario, IConfiguration configMicrosoft)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(configMicrosoft.GetSection("AppSettings:SecretTokenKey").Value!));

            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms
                .HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1),
                signingCredentials: credenciales);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
