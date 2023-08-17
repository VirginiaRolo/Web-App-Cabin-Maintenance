using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hotel.LogicaNegocio.Excepciones;

namespace Hotel.LogicaNegocio.Entidades
{
    public class Mantenimiento : IValidable
    {
        // ESTO CAMBIA A CONFIG
        #region CONSTANTES
        // Si cambiase la longitud hay que cambiar estas 3 cosas
        private const int descMinLength = 10;
        private const int descMaxLength = 200;
        // Hice esta constante porque el ErrorMessage requiere que sea un string constante
        private const string descLengthError = "Largo de la descripción: entre 10 y 200 caracteres.";
        #endregion

        #region PROPERTIES
        [Column("IdMantenimiento", Order = 0)]
        public int Id { get; set; }

        [Column(Order = 5)]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        //[StringLength(descMaxLength, MinimumLength = descMinLength, ErrorMessage = descLengthError)]
        public DescripcionMantenimiento Descripcion { get; set; }

        public CostoMantenimiento Costo { get; set; }

        [Column("NombreDelFunc", Order = 2), DataType(DataType.Text), Required]
        [Display(Name = "Nombre del Funcionario")]
        public string NombreFuncionario { get; set; }

        [Column("IdCabania", Order = 1)]
        [Display(Name = "Número de Habitación")]
        [ForeignKey(nameof(Cabania))] public int CabaniaId { get; set; }
        public Cabania Cabania { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public Mantenimiento() {
            Descripcion = new DescripcionMantenimiento();
            Costo = new CostoMantenimiento();
            //Descripcion.Valor = "Placeholder";
            //Costo.Valor = 0;
        }

        //Todos los parámetros
        public Mantenimiento(DateTime fecha, string descripcion, double costo,
            string nombreFuncionario, Cabania cabania)
        {
            Fecha = fecha;
            Descripcion.Valor = descripcion;
            Costo.Valor = costo;
            NombreFuncionario = nombreFuncionario;
            Cabania = cabania;
        }

        #endregion

        #region MÉTODOS
        public void Validar(IRepositorioConfiguracion configuracion)
        {
            ValidarFecha();
            Descripcion.Validar(configuracion);
            Costo.Validar(configuracion);
            ValidarNombreFuncionario(); 
        }

        public void ValidarFecha()
        {
            if (Fecha == default(DateTime) || Fecha > DateTime.Now)
            {
                throw new MantenimientoException($"Error: La fecha ingresada debe ser menor " +
                    $"o igual al día de hoy.");
            }
        }

        public void ValidarNombreFuncionario()
        {
            if (string.IsNullOrEmpty(NombreFuncionario))
            {
                throw new MantenimientoException("Error: El nombre del funcionario no puede ser " +
                    "nulo ni vacío.");
            }
        }
        #endregion
    }
}
