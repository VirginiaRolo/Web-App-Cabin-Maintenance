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
    public class GetCabaniasByNombreUC : IGetCabaniasByNombreUC
    {
        public IRepositorioCabania repo;

        public GetCabaniasByNombreUC(IRepositorioCabania repositorioCabania)
        {
            repo = repositorioCabania;
        }

        public IEnumerable<Cabania> GetCabaniasByNombre(string nombre)
        {
            try
            {
                return repo.GetByNombre(nombre);
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
