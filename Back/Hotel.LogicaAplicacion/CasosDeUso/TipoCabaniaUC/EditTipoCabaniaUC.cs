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
    public class EditTipoCabaniaUC : IEditTipoCabaniaUC
    {
        #region ATRIBUTOS
        public IRepositorioTipoCabania repo;

        public IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public EditTipoCabaniaUC(
            IRepositorioTipoCabania repositorioTipoCabania,
            
            IRepositorioConfiguracion config)
        {
            repo = repositorioTipoCabania;

            this.config = config;
        }
        #endregion

        public void UpdateTipoCabania(TipoCabaniaEditDto tipoCabaniaEditDto, string nombre)
        {
            try
            {
                TipoCabania existenteTipoCabania = repo.GetByNombreTipoCabania(nombre);

                existenteTipoCabania.Descripcion = new DescripcionTipoCabania(tipoCabaniaEditDto
                    .Descripcion, config);
                existenteTipoCabania.Costo = new CostoTipoCabania(tipoCabaniaEditDto.Costo,
                    config);

                repo.UpdateConConfig(existenteTipoCabania, nombre, config);
            }
            catch (TipoCabaniaException tce)
            {
                throw tce;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
