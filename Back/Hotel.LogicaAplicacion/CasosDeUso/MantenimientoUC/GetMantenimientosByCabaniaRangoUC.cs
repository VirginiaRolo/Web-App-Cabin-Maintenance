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
    public class GetMantenimientosByCabaniaRangoUC : IGetMantenimientosByCabaniaRangoUC
    {
        #region ATRIBUTOS
        public IRepositorioMantenimiento repo;

        public IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public GetMantenimientosByCabaniaRangoUC(
            IRepositorioMantenimiento repositorioMantenimiento,

            IRepositorioConfiguracion config)
        {
            repo = repositorioMantenimiento;

            this.config = config;
        }
        #endregion


        public IEnumerable<Mantenimiento> GetByCapacidadCabaniaRango(int capMin, int capMax)
        {
            try
            {
                return repo.GetByCapacidadCabaniaRango(capMin, capMax, config);

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
