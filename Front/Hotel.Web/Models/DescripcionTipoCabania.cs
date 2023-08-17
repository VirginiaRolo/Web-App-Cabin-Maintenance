using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.Web.Models
{
    public class DescripcionTipoCabania
    {
        //[Required(ErrorMessage = "La descripción no puede ser nula.")]
        //[Display(Name = "Descripción")]
        //[DataType(DataType.Text)]
        public string Valor { get; set; }
    }
}