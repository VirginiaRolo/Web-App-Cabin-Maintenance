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
    public class GetCabaniasByTipoUC : IGetCabaniasByTipoUC
    {
        public IRepositorioCabania repo;

        public GetCabaniasByTipoUC(IRepositorioCabania repositorioCabania)
        {
            repo = repositorioCabania;
        }

        public IEnumerable<Cabania> GetCabaniasByTipo(string tipo)
        {
            try
            {
                return repo.GetByTipo(tipo);

            }           
                catch (CabaniaException ex)
            {

                throw ex;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
