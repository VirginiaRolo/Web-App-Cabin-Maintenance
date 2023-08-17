using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAccesoDatos.SqlRepositorios
{
    public class SqlRepositorioTipoCabania : IRepositorioTipoCabania
    {
        // Debemos poder acceder al contexto para utilizar los métodos de Sql
        public HotelContext Context { get; set; }

        // Inicializamos el context en la creación de esto (SqlRepositorio... - ... = lo que sea)
        #region CONSTRUCTOR
        public SqlRepositorioTipoCabania()
        {
            Context = new HotelContext();
        }
        #endregion

        public void CreateConConfig(TipoCabania tipoCabania, IRepositorioConfiguracion configuracion)
        {
            try
            {
                tipoCabania.Validar(configuracion);
                Context.TiposCabanias.Add(tipoCabania);
                Context.SaveChanges();
            }
            catch (TipoCabaniaException tce)
            {
                throw tce;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw new TipoCabaniaException("Error");
            }
        }

        public void DeleteTipoCabania(string nombre)
        {
            try
            {
                TipoCabania ret = GetByNombreTipoCabania(nombre);

                bool tieneCabania = Context.Cabanias.Any(cab => cab.NombreTipoCabania == nombre);

                if (!tieneCabania)
                {
                    Context.Remove(ret);
                    Context.SaveChanges();
                }
                else
                {
                    throw new TipoCabaniaException("El tipo de cabaña está siendo utilizado, no puede ser eliminado.");

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw e;
            }

        }

        public IEnumerable<TipoCabania> GetAll()
        {
            try
            {
                return Context.TiposCabanias.OrderBy(tipoCab => tipoCab.Nombre).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw new Exception("Error");
            }
        }

        public IEnumerable<TipoCabania> GetByNombre(string nombre)
        {
            try
            {
                return GetAll().Where(tipoCab => tipoCab.Nombre == nombre).OrderBy(tipoCab => tipoCab.Nombre);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw new Exception("Error");
            }
        }
        public TipoCabania GetByNombreTipoCabania(string nombre)
        {
            try
            {
                var TipoCabaniaRet = Context.TiposCabanias.Where(tipoCab => tipoCab.Nombre == nombre).FirstOrDefault();
                return TipoCabaniaRet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw new Exception("Error");
            }
        }

        public void UpdateConConfig(TipoCabania tipoCab, string nombre, IRepositorioConfiguracion configuracion)
        {
            try
            {
                //TipoCabania ret = GetByNombreTipoCabania(nombre);
                //ret.Descripcion.Valor = descripcion;
                //ret.Costo.Valor = costo;
                tipoCab.Validar(configuracion);
                Context.Update(tipoCab);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw new Exception("Error");
            }
        }

        #region MÉTODOS QUE NO USAMOS
        public bool IsEnUso(TipoCabania tipo)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoCabania tipo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoCabania GetById(int id)
        {
            // Despues esto cambia
            return Context.TiposCabanias.ToList()[id];
        }

        public void Create(TipoCabania t)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
