using Hotel.LogicaNegocio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DTOs
{
    public class CabaniaDto
    {
        #region PROPERTIES
        public string TipoNombre { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool TieneJacuzzi { get; set; }

        public bool HabilitadaReservas { get; set; }

        public int CantMaxPersonas { get; set; }

        public string? Foto { get; set; }
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public CabaniaDto(){}

        public CabaniaDto(Cabania cabania)
        {
            this.Nombre = cabania.Nombre;
            this.Descripcion = cabania.Descripcion;
            this.TieneJacuzzi = cabania.TieneJacuzzi;
            this.HabilitadaReservas = cabania.HabilitadaReservas;
            this.CantMaxPersonas = cabania.CantMaxPersonas;
            this.Foto = cabania.Foto;
        }
        #endregion
    }
}