using DTOs;
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
    public class CreateTipoCabaniaUC : ICreateTipoCabaniaUC
    {
        #region ATRIBUTOS
        public IRepositorioTipoCabania repo;

        public IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public CreateTipoCabaniaUC(
            IRepositorioTipoCabania repositorioTipoCabania,
            IRepositorioConfiguracion config)
        {
            repo = repositorioTipoCabania;
            this.config = config;
        }
        #endregion


        public void CreateTipoCabania(TipoCabaniaDto tipoCabaniaDto)
        {
            try
            {
                TipoCabania nuevoTipoCabania = new TipoCabania();

                nuevoTipoCabania.Nombre = tipoCabaniaDto.Nombre;
                nuevoTipoCabania.Descripcion = new DescripcionTipoCabania(tipoCabaniaDto.Descripcion, config);
                nuevoTipoCabania.Costo = new CostoTipoCabania(tipoCabaniaDto.Costo, config);

                repo.CreateConConfig(nuevoTipoCabania, config);
            }
            catch (TipoCabaniaException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
