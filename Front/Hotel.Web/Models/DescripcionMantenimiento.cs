using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.Web.Models
{
    public class DescripcionMantenimiento
    {
        //[Display(Name = "Descripción")]
        //[DataType(DataType.Text)]
        public string Valor { get; set; }
    }
}