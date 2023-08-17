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
    public class DeleteTipoCabaniaUC : IDeleteTipoCabaniaUC
    {
        public IRepositorioTipoCabania repo;

        public DeleteTipoCabaniaUC(IRepositorioTipoCabania repositorioTipoCabania)
        {
            repo = repositorioTipoCabania;
        }

        public void DeleteTipoCabania(string nombre)
        {
            try
            {
                repo.DeleteTipoCabania(nombre);

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
