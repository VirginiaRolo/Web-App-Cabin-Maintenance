using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.Web.Models
{
    public class CostoTipoCabania
    {
        //[Required(ErrorMessage = "El costo no puede ser nulo.")]
        //[Display(Name = "Costo")]
        //[DataType(DataType.Currency)]
        public double Valor { get; set; }
    }
}