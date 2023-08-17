using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;

namespace Hotel.LogicaAplicacion.CasosDeUso.TipoCabaniaUC
{
    public class GetTiposDeCabaniaUC : IGetTiposDeCabaniaUC
    {
        public IRepositorioTipoCabania repo;

        public GetTiposDeCabaniaUC(IRepositorioTipoCabania repositorioTipoCabania)
        {
            repo = repositorioTipoCabania;
        }

        public IEnumerable<TipoCabania> GetTiposCabania()
        {
            try
            {
                return repo.GetAll();

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