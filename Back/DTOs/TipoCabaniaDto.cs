using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoCabaniaDto
    {
        #region PROPERTIES

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double Costo { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public TipoCabaniaDto() { }

        public TipoCabaniaDto(TipoCabania tipoCabania)
        {
            this.Nombre = tipoCabania.Nombre;
            this.Descripcion = tipoCabania.Descripcion.Valor;
            this.Costo = tipoCabania.Costo.Valor;
        }
        #endregion
    }
}
