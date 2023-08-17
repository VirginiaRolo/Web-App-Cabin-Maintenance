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
    public class GetTiposDeCabaniaByNombreUC : IGetTiposDeCabaniaByNombreUC
    {
        public IRepositorioTipoCabania repo;

        public GetTiposDeCabaniaByNombreUC(IRepositorioTipoCabania repositorioTipoCabania)
        {
            repo = repositorioTipoCabania;
        }

        public IEnumerable<TipoCabania> GetTiposCabaniaByNombre(string nombre)
        {
            try
            {
                return repo.GetByNombre(nombre);
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
