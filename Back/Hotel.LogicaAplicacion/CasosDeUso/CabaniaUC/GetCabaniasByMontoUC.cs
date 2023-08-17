using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.CasosDeUso.CabaniaUC
{
    public class GetCabaniasByMontoUC : IGetCabaniasByMontoUC
    {
        #region ATRIBUTOS
        public IRepositorioCabania repo;

        public IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public GetCabaniasByMontoUC(
            IRepositorioCabania repositorioCabania,

            IRepositorioConfiguracion config)
        {
            repo = repositorioCabania;

            this.config = config;
        }
        #endregion

        public IEnumerable<Cabania> GetCabaniasByMonto(double monto)
        {
            try
            {
                return repo.GetCabaniasByMonto(monto);

            }
            catch (CabaniaException ce)
            {
                throw ce;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
