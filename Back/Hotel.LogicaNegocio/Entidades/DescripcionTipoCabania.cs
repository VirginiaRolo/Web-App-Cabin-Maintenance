using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.LogicaNegocio.Entidades
{
    [Owned]
    public class DescripcionTipoCabania : IValidable
    {
        [Required(ErrorMessage = "La descripción no puede ser nula.")]
        [Column("Descripcion_Valor", Order = 1)]
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        public string Valor { get; set; }

        #region CONSTRUCTORES
        // Vacío
        public DescripcionTipoCabania(){}

        public DescripcionTipoCabania(string valor, IRepositorioConfiguracion configuracion)
        {
            Valor = valor;
            Validar(configuracion);
        }
        #endregion

        public void Validar(IRepositorioConfiguracion configuracion)
        {
            int limiteSuperior = configuracion.GetSuperiorByNombre("TipoCabaniaDescripcion");
            int limiteInferior = configuracion.GetInferiorByNombre("TipoCabaniaDescripcion");

            if (string.IsNullOrEmpty(Valor) || Valor.Length < limiteInferior || Valor.Length > limiteSuperior)
            {
                throw new TipoCabaniaException($"Error: El largo de la descripción debe ser entre {limiteInferior} y {limiteSuperior} caracteres.");
            }
        }
    }
}