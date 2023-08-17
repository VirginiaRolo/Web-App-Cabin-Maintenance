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
    public class GetMantenimientosByCabaniaIdUC : IGetMantenimientosByCabaniaIdUC
    {
        public IRepositorioMantenimiento repo;

        public GetMantenimientosByCabaniaIdUC(IRepositorioMantenimiento repositorioMantenimiento)
        {
            repo = repositorioMantenimiento;
        }

        public IEnumerable<Mantenimiento> GetMantenimientosByCabaniaId(int idCabania)
        {
            try
            {
                return repo.GetByIdCabania(idCabania);
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
