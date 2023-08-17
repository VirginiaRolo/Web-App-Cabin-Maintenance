using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.LogicaNegocio.Entidades
{
    [Table("TipoDeCabania")]
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoCabania : IValidable
    {
        // ESTO CAMBIA A CONFIG
        #region CONSTANTES
        //DESCRIPCIÓN
        // Si cambiase la longitud hay que cambiar estas 3 cosas
        private const int descMinLength = 10;
        private const int descMaxLength = 200;
        // Hice esta constante porque el ErrorMessage requiere que sea un string constante
        private const string descLengthError = "Largo de la descripción: entre 10 y 200 caracteres.";

        //COSTO
        private const double costoMinimo = 0;
        // Hice esta constante porque el ErrorMessage requiere que sea un string constante
        private const string costoMinimoError = "Debe ingresar un costo positivo";
        #endregion

        #region PROPERTIES
        [Column("IdTipoCabania", Order = 0)]
        [Key, Required(ErrorMessage = "El nombre no puede ser nulo."), DataType(DataType.Text)]
        public string Nombre { get; set; }

        //[StringLength(descMaxLength, MinimumLength = descMinLength, ErrorMessage = descLengthError)]
        public DescripcionTipoCabania Descripcion { get; set; }

        //[Range(costoMinimo, double.MaxValue, ErrorMessage = costoMinimoError)]
        public CostoTipoCabania Costo { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        //Inicializando los value objects
        public TipoCabania() {
            Descripcion = new DescripcionTipoCabania();
            Costo = new CostoTipoCabania();
            Descripcion.Valor = "Placeholder";
            Costo.Valor = 0;
        }

        // Todos los parámetros
        public TipoCabania(string nombre, string descripcion, double costo)
        {
            Nombre = nombre;
            Descripcion.Valor = descripcion;
            Costo.Valor = costo;
        }
        #endregion

        #region MÉTODOS
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            ValidarNombre();
            Descripcion.Validar(configuracion);
            Costo.Validar(configuracion);
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new TipoCabaniaException("Error: El nombre no puede ser nulo ni vacío.");
            }
            if (!Regex.IsMatch(Nombre, @"^([a-zA-Z])(([a-zA-Z]| )*([a-zA-Z]))*$"))
            // ^ -> Si o si empezame con esto 
            // * -> 0 o más
            // $ -> Si o si terminame con esto
            // RESUMEN: Empieza con una letra y termina con
            // 0 o mas (los espacios y letras que quieras y una letra para el final)
            {
                throw new TipoCabaniaException("Error: El nombre debe incluir solo caracteres alfabéticos y puede incluir espacios embebidos (no al principio ni al final).");
            }
        }
        #endregion
    }
}
