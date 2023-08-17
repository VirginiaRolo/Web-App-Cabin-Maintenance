namespace Hotel.Web.Models
{
    public class MantenimientoModel
    {
        public DateTime Fecha { get; set; }

        public DescripcionMantenimiento Descripcion { get; set; }

        public string MantenimientoDescripcion { get; set; }

        public CostoMantenimiento Costo { get; set; }

        public double MantenimientoCosto { get; set; }

        public string NombreFuncionario { get; set; }

        public CabaniaModel Cabania { get; set; }

        public int IdCabania { get; set; }
    }
}
