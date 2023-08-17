using DTOs;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.CasosDeUso.MantenimientoUC
{
    public class CreateMantenimientoUC : ICreateMantenimientoUC
    {
        #region ATRIBUTOS
        public IRepositorioMantenimiento repo;

        public IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public CreateMantenimientoUC(
            IRepositorioMantenimiento repositorioMantenimiento,

            IRepositorioConfiguracion config)
        {
            repo = repositorioMantenimiento;

            this.config = config;
        }
        #endregion

        public void CreateMantenimiento(MantenimientoDto mantenimientoDto)
        {
            try
            {
                //Cabania existenteCabania = repoCabania.GetById(idCabania);
                Mantenimiento nuevoMantenimiento = new Mantenimiento();

                nuevoMantenimiento.CabaniaId = mantenimientoDto.IdCabania;
                nuevoMantenimiento.Fecha = mantenimientoDto.Fecha;
                nuevoMantenimiento.Descripcion = new DescripcionMantenimiento(mantenimientoDto.Descripcion, config);
                nuevoMantenimiento.Costo = new CostoMantenimiento(mantenimientoDto.Costo, config);
                nuevoMantenimiento.NombreFuncionario = mantenimientoDto.NombreFuncionario;
                //nuevoMantenimiento.CabaniaId = mantenimientoDto.idCabania;
                //nuevoMantenimiento.Cabania = existenteCabania;

                repo.CreateConConfig(nuevoMantenimiento, config);
            }
            catch (MantenimientoException me)
            {
                throw me;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
