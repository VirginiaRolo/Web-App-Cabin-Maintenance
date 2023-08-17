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
    public class GetCabaniasUC : IGetCabaniasUC
    {
        public IRepositorioCabania repo;

        public GetCabaniasUC(IRepositorioCabania repositorioCabania)
        {
            repo = repositorioCabania;
        }

        public IEnumerable<Cabania> GetCabanias()
        {
            try
            {
                return repo.GetAll();

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
