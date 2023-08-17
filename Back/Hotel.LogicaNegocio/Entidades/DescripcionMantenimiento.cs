using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.LogicaNegocio.Entidades
{
    [Owned]
    public class DescripcionMantenimiento: IValidable
    {
        [Column("Descripcion_Valor", Order = 3)]
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        public string Valor { get; set; }

        #region CONSTRUCTORES
        public DescripcionMantenimiento(){}

        public DescripcionMantenimiento(string valor, IRepositorioConfiguracion configuracion)
        {
            Valor = valor;
            Validar(configuracion);
        }
        #endregion

        public void Validar(IRepositorioConfiguracion configuracion)
        {
            int limiteSuperior = configuracion.GetSuperiorByNombre("MantenimientoDescripcion");
            int limiteInferior = configuracion.GetInferiorByNombre("MantenimientoDescripcion");

            if (string.IsNullOrEmpty(Valor) || Valor.Length < limiteInferior || Valor.Length > limiteSuperior)
            {
                throw new MantenimientoException($"Error: El largo de la descripción debe ser entre {limiteInferior} y {limiteSuperior} caracteres.");
            }
        }
    }
}