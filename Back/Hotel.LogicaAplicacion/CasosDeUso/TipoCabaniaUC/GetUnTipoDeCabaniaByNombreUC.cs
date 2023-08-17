using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.CasosDeUso.TipoCabaniaUC
{
    public class GetUnTipoDeCabaniaByNombreUC : IGetUnTipoDeCabaniaByNombreUC
    {
        public IRepositorioTipoCabania repo;

        public GetUnTipoDeCabaniaByNombreUC(IRepositorioTipoCabania repositorioTipoCabania)
        {
            repo = repositorioTipoCabania;
        }

        public TipoCabania GetUnTipoCabaniaByNombre(string nombre)
        {
            try
            {
                return repo.GetByNombreTipoCabania(nombre);
            }
            catch (TipoCabaniaException ex)
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
