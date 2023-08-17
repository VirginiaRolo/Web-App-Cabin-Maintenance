using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.LogicaNegocio.Entidades
{
    [Owned]
    public class CostoTipoCabania : IValidable
    {
        [Required(ErrorMessage = "El costo no puede ser nulo.")]
        [Column("Costo_Valor", Order = 2)]
        [Display(Name = "Costo")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }

        #region CONSTRUCTORES
        // Vacío
        public CostoTipoCabania(){}

        public CostoTipoCabania(double valor, IRepositorioConfiguracion configuracion)
        {
            Valor = valor;
            Validar(configuracion);
        }
        #endregion

        public void Validar(IRepositorioConfiguracion configuracion)
        {
            if (Valor < 0)
            {
                throw new TipoCabaniaException($"Error: El costo debe ser mayor a cero");
            }
        }
    }
}