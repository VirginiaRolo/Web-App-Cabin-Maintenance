using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace Hotel.LogicaNegocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    [Index(nameof(NumeroHabitacion), IsUnique = true)]
    public class Cabania : IValidable
    {
        // ESTO CAMBIA A CONFIG
        #region CONSTANTES
        // Si cambiase la longitud hay que cambiar estas 3 cosas
        private const int descMinLength = 10;
        private const int descMaxLength = 500;
        // Hice esta constante porque el ErrorMessage requiere que sea un string constante
        private const string descLengthError = "Largo de la descripción: entre 10 y 500 caracteres.";
        #endregion

        #region PROPERTIES
        [Column("IdTipoCabania", Order = 1)]
        [Display(Name = "Tipo de Cabaña")]
        [Required(ErrorMessage = "Debe que seleccionar un tipo.")]
        [ForeignKey(nameof(Tipo))] public string NombreTipoCabania { get; set; }
        public TipoCabania Tipo { get; set; }

        [Column(Order = 2)]
        [DataType(DataType.Text), Required(ErrorMessage = "El nombre no puede ser nulo.")]
        public string Nombre { get; set; }

        [Column("Descripcion", Order = 3), Required]
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        //[StringLength(descMaxLength, MinimumLength = descMinLength, ErrorMessage = descLengthError)]
        public string Descripcion { get; set; }

        [Column("TieneJacuzzi", Order = 6)]
        [Display(Name = "Tiene Jacuzzi")]
        public bool TieneJacuzzi { get; set; }

        [Column("HabilitadaParaReservas", Order = 5)]
        [Display(Name = "Habilitada para Reservas")]
        public bool HabilitadaReservas { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCabania", Order = 0), Required]
        [Display(Name = "Número de Habitación")]
        public int NumeroHabitacion { get; set; }

        [Column("CantMaxPersonas", Order = 4), Required(ErrorMessage = "Debe ingresar una cantidad.")]
        [Display(Name = "Cantidad Máxima de Personas")]
        public int CantMaxPersonas { get; set; }

        [Column(Order = 7)]
        [DataType(DataType.ImageUrl)]
        public string? Foto { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public Cabania() { }

        // Todos los parámetros
        public Cabania(
            TipoCabania tipoCabania,
            string nombre,
            string descripcion,
            bool tieneJacuzzi,
            bool habilitadaReservas,
            int cantMaxPersonas,
            string foto)
        {
            Tipo = tipoCabania;
            Nombre = nombre;
            Descripcion = descripcion;
            TieneJacuzzi = tieneJacuzzi;
            HabilitadaReservas = habilitadaReservas;
            CantMaxPersonas = cantMaxPersonas;
            Foto = foto;
        }
        #endregion

        #region MÉTODOS
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            ValidarNombre();
            ValidarDescripcion(configuracion);
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new CabaniaException("Error: El nombre no puede ser nulo ni vacío.");
            }
            if (!Regex.IsMatch(Nombre, @"^([a-zA-Z])(([a-zA-Z]| )*([a-zA-Z]))*$"))
            // ^ -> Si o si empezame con esto 
            // * -> 0 o más
            // $ -> Si o si terminame con esto
            // RESUMEN: Empieza con una letra y termina con
            // 0 o mas (los espacios y letras que quieras y una letra para el final)
            {
                throw new CabaniaException("Error: El nombre debe incluir solo caracteres " +
                    "alfabéticos y puede incluir espacios embebidos " +
                    "(no al principio ni al final).");
            }
        }

        public void ValidarDescripcion(IRepositorioConfiguracion configuracion)
        {
            int limiteSuperior = configuracion.GetSuperiorByNombre("CabaniaDescripcion");
            int limiteInferior = configuracion.GetInferiorByNombre("CabaniaDescripcion");

            if (string.IsNullOrEmpty(Descripcion) || Descripcion.Length < limiteInferior
                || Descripcion.Length > limiteSuperior)
            {
                throw new CabaniaException($"Error: El largo de la descripción " +
                    $"debe ser entre {limiteInferior} y {limiteSuperior} caracteres.");
            }
        }
        #endregion
    }
}
