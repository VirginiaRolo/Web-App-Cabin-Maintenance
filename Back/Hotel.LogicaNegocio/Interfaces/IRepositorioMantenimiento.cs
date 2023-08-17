using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IRepositorioMantenimiento : IRepositorio<Mantenimiento>
    {
        public void CreateConConfig(Mantenimiento mantenimiento, IRepositorioConfiguracion configuracion);
        public IEnumerable<Mantenimiento> GetByIdCabania(int idCabania);
        public IEnumerable<Mantenimiento> GetByIdCabaniaYDosFechas(int idCabania, DateTime fecha1, DateTime fecha2);
        public List<Mantenimiento> GetByIdCabaniaYUnaFecha(int idCabania, DateTime fechaMantenimiento);
        public bool VerificarMantenimientosPorDia(List<Mantenimiento> mantXDiaDeUnaCab);
        public IEnumerable<Mantenimiento> GetByCapacidadCabaniaRango(int capMin, int capMax, IRepositorioConfiguracion configuracion);
        //public void Create(int idCabania, Mantenimiento mantenimiento);
    }
}
