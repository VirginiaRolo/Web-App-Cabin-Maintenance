using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public class MantenimientoDto
    {
        #region PROPERTIES
        public int IdCabania { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string NombreFuncionario { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public MantenimientoDto() { }

        public MantenimientoDto(Mantenimiento mantenimiento)
        {
            this.Fecha = mantenimiento.Fecha;
            this.Descripcion = mantenimiento.Descripcion.Valor;
            this.Costo = mantenimiento.Costo.Valor;
            this.NombreFuncionario = mantenimiento.NombreFuncionario;
        }
        #endregion
    }
}
