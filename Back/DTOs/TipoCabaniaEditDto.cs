using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoCabaniaEditDto
    {
        #region PROPERTIES
        public string Descripcion { get; set; }

        public double Costo { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public TipoCabaniaEditDto() { }

        public TipoCabaniaEditDto(TipoCabania tipoCabania)
        {
            this.Descripcion = tipoCabania.Descripcion.Valor;
            this.Costo = tipoCabania.Costo.Valor;
        }
        #endregion
    }
}
