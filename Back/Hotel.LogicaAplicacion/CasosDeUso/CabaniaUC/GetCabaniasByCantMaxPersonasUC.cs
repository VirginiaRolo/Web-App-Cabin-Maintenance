using DTOs;
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
    public class GetCabaniasByCantMaxPersonasUC : IGetCabaniasByCantMaxPersonasUC
    {
        public IRepositorioCabania repo;

        public GetCabaniasByCantMaxPersonasUC(IRepositorioCabania repositorioCabania)
        {
            repo = repositorioCabania;
        }

        public IEnumerable<Cabania> GetCabaniasByCantMaxPersonas(int cantMaxPersonas)
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = repo.GetByCantMaxPersonas(cantMaxPersonas);

                //List<CabaniaDto> listaCabaniasDto = new List<CabaniaDto>();

                //foreach (var cabania in listaCabanias)
                //{
                //    listaCabaniasDto.Add(cabania as CabaniaDto);
                //}

                //IEnumerable<CabaniaDto> listaCabaniasDto =  listaCabanias as IEnumerable<CabaniaDto>;

                return listaCabanias;
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
