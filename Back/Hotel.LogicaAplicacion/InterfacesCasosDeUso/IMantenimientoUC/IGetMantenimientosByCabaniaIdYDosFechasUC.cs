using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC
{
    public interface IGetMantenimientosByCabaniaIdYDosFechasUC
    {
        public IEnumerable<Mantenimiento> GetMantenimientosByCabaniaIdYDosFechas(int idCabania, DateTime fecha1, DateTime fecha2);
    }
}
