using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Entidades
{
    public class Configuracion
    {
        #region PROPERTIES
        [Key]
        [Column("NombreAtributo", Order = 0)]
        public string Atributo { get; set; }
        public int LimiteSuperior { get; set; }
        public int LimiteInferior { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Configuracion(){}
        #endregion

        #region MÉTODOS
        #endregion
    }
}
