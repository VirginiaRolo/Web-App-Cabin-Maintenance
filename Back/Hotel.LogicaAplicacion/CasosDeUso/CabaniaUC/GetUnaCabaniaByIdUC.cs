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
    public class GetUnaCabaniaByIdUC : IGetUnaCabaniaByIdUC
    {
        public IRepositorioCabania repo;

        public GetUnaCabaniaByIdUC(IRepositorioCabania repositorioCabania)
        {
            repo = repositorioCabania;
        }

        public Cabania GetUnaCabaniaById(int idCabania)
        {
            try
            {
            return repo.GetById(idCabania);

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
