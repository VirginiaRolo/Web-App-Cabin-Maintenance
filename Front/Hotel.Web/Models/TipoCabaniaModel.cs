using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Hotel.Web.Models
{
    public class TipoCabaniaModel
    {
        public string Nombre { get; set; }

        public DescripcionTipoCabania? Descripcion { get; set; }

        public string? TipoDescripcion { get; set; }

       public CostoTipoCabania? Costo { get; set; }

        public double? TipoCosto { get; set; }
    }
}