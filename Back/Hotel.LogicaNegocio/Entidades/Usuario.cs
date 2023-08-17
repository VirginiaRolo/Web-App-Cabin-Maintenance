using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Hotel.LogicaNegocio.Interfaces;
using Hotel.LogicaNegocio.Excepciones;

namespace Hotel.LogicaNegocio.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable
    {
        // ESTO CAMBIA A CONFIG
        #region CONSTANTES
        // Si cambiase la longitud hay que cambiar estas 2 cosas
        private const int minLength = 6;
        // Hice esta constante porque el ErrorMessage requiere que sea un string constante
        private const string minLengthError = "Mínimo de caracteres: 6.";
        #endregion

        #region PROPERTIES
        [Column("IdUsuario", Order = 0)]
        public int Id { get; set; }

        [Column(Order = 1)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column("Contrasenia", Order = 2), DataType(DataType.Password), MinLength(minLength, ErrorMessage = minLengthError)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public Usuario() { }

        // Todos los parámetros
        protected Usuario(string email, string contrasenia)
        {
            Email = email;
            Contrasenia = contrasenia;
        }
        #endregion

        #region MÉTODOS
        public virtual void Validar(IRepositorioConfiguracion configuracion)
        {
            ValidarEmail();
            ValidarContrasenia();
        }

        public virtual void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new UsuarioException("Error: El e-mail no puede ser nulo ni vacío.");
            }
            if (!Regex.IsMatch(Email, @"^([a-zA-Z]|[0-9])+@[a-z]+(\.[a-z]+)+$"))
            {
                throw new UsuarioException("Error: El email no es válido.");
            }
        }

        public virtual void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new UsuarioException("Error: La contraseña no puede ser nula ni vacía.");
            }
            if (Contrasenia.Length < 6)
            {
                throw new UsuarioException("Error: La contraseña debe tener al menos 6 caracteres.");
            }
            // Al menos una letra mayuscula, al menos una letra minus y al menos 1 digito del 0 al 9
            if (!Regex.IsMatch(Contrasenia, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"))
            {
                throw new UsuarioException("Error: El email no es válido.");
            }
        }
        #endregion
    }
}
