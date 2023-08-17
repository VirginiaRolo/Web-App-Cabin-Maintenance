using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAccesoDatos.SqlRepositorios
{
    public class SqlRepositorioConfiguracion : IRepositorioConfiguracion
    {
        // Debemos poder acceder al contexto para utilizar los métodos de Sql
        public HotelContext Context { get; set; }

        // Inicializamos el context en la creación de esto (SqlRepositorio... - ... = lo que sea)
        #region CONSTRUCTOR
        public SqlRepositorioConfiguracion()
        {
            Context = new HotelContext();
        }
        #endregion

        public int GetSuperiorByNombre(string nombre)
        {
            try
            {
                Configuracion config = Context.Configuraciones.Where(conf => conf.Atributo == nombre).FirstOrDefault();

                if (config == null)
                {
                    throw new Exception("Nombre de atributo incorrecto.");
                }

                return config.LimiteSuperior;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int GetInferiorByNombre(string nombre)
        {
            try
            {
                Configuracion config = Context.Configuraciones.Where(conf => conf.Atributo == nombre).FirstOrDefault();

                if (config == null)
                {
                    throw new Exception("Nombre de atributo incorrecto.");
                }

                return config.LimiteInferior;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #region MÉTODOS QUE NO USAMOS
        public void Create(Configuracion t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Configuracion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Configuracion t)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
