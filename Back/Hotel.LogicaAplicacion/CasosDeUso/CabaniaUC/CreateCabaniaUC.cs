using DTOs;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
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
    public class CreateCabaniaUC : ICreateCabaniaUC
    {
        #region ATRIBUTOS
        public IRepositorioCabania repo;
        public IRepositorioTipoCabania repoTipo;

        public IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public CreateCabaniaUC(
                    IRepositorioCabania repositorioCabania,
                    IRepositorioTipoCabania repoTipo,

                    IRepositorioConfiguracion config)
        {
            repo = repositorioCabania;
            this.repoTipo = repoTipo;

            this.config = config;
        }
        #endregion

        public void CreateCabania(CabaniaDto cabaniaDto)
        {
            try
            {
                Cabania nuevaCabania = new Cabania();

                nuevaCabania.NombreTipoCabania = cabaniaDto.TipoNombre;
                nuevaCabania.Nombre = cabaniaDto.Nombre;
                nuevaCabania.Descripcion = cabaniaDto.Descripcion;
                nuevaCabania.TieneJacuzzi = cabaniaDto.TieneJacuzzi;
                nuevaCabania.HabilitadaReservas = cabaniaDto.HabilitadaReservas;
                nuevaCabania.CantMaxPersonas = cabaniaDto.CantMaxPersonas;
                nuevaCabania.Foto = cabaniaDto.Foto;

                repo.CreateConConfig(nuevaCabania, config);
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
