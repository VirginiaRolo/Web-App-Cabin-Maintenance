using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.Web.Models
{
    public class CabaniaModel
    {
        public string TipoNombre { get; set; }

        public TipoCabaniaModel Tipo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool TieneJacuzzi { get; set; }

        public bool HabilitadaReservas { get; set; }

        public int NumeroHabitacion { get; set; }

        public int CantMaxPersonas { get; set; }

        public string? Foto { get; set; }
    }
}