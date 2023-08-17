using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel.LogicaNegocio.Entidades
{
    [Owned]
    public class CostoMantenimiento: IValidable
    {
        [Column("Costo_Valor", Order = 4)]
        [Display(Name = "Costo")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }

        #region CONSTRUCTORES
        public CostoMantenimiento(){}

        public CostoMantenimiento(double valor, IRepositorioConfiguracion configuracion)
        {
            Valor = valor;
            Validar(configuracion);
        }
        #endregion

        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if (Valor <= 0 )
            {
                throw new MantenimientoException($"Error: El costo debe ser mayor a cero");
            }
        }
    }
}