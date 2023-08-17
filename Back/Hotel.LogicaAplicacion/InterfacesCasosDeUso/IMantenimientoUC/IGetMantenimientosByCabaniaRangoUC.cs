using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC
{
    public interface IGetMantenimientosByCabaniaRangoUC
    {
        IEnumerable<Mantenimiento> GetByCapacidadCabaniaRango(int capMin, int capMax);
    }
}
