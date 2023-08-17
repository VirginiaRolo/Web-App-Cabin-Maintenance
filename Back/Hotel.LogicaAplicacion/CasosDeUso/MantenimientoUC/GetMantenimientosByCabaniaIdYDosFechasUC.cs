using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.CasosDeUso.MantenimientoUC
{
    public class GetMantenimientosByCabaniaIdYDosFechasUC : IGetMantenimientosByCabaniaIdYDosFechasUC
    {
        public IRepositorioMantenimiento repo;

        public GetMantenimientosByCabaniaIdYDosFechasUC(IRepositorioMantenimiento repositorioMantenimiento)
        {
            repo = repositorioMantenimiento;
        }

        public IEnumerable<Mantenimiento> GetMantenimientosByCabaniaIdYDosFechas(int idCabania, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return repo.GetByIdCabaniaYDosFechas(idCabania, fecha1, fecha2);

            }
            catch (MantenimientoException me)
            {
                throw me;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
