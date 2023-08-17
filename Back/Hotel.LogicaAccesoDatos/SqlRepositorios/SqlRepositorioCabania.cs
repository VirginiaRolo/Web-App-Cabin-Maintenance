using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAccesoDatos.SqlRepositorios
{
    public class SqlRepositorioCabania : IRepositorioCabania
    {
        // Debemos poder acceder al contexto para utilizar los métodos de Sql
        public HotelContext Context { get; set; }

        // Inicializamos el context en la creación de esto (SqlRepositorio... - ... = lo que sea)
        #region CONSTRUCTOR
        public SqlRepositorioCabania()
        {
            Context = new HotelContext();
        }
        #endregion

        //CREATE
        public void CreateConConfig(Cabania cabania, IRepositorioConfiguracion configuracion)
        {
            try
            {
                cabania.Validar(configuracion);
                Context.Cabanias.Add(cabania);
                Context.SaveChanges();
            }
            catch (CabaniaException ce)
            {
                throw ce;
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        //GETALL
        public IEnumerable<Cabania> GetAll()
        {
            try
            {
                return Context.Cabanias.Include("Tipo").OrderBy(cab => cab.NumeroHabitacion)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        //GETBYCANTMAXPERSONAS
        public IEnumerable<Cabania> GetByCantMaxPersonas(int numero)
        {
            try
            {
                return Context.Cabanias.Include("Tipo").Where(cab => cab.CantMaxPersonas
                >= numero).OrderBy(cab => cab.Nombre).ToList();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        //GETBYHABILITADA
        public IEnumerable<Cabania> GetByHabilitada()
        {
            try
            {
                return Context.Cabanias.Include("Tipo").Where(cab => cab.HabilitadaReservas
                == true).OrderBy(cab => cab.Nombre).ToList();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }

        }

        //GETBYID
        public Cabania GetById(int id)
        {
            try
            {
                return Context.Cabanias.Include("Tipo").Where(cab => cab.NumeroHabitacion == id)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        //GETBYNOMBRE
        public IEnumerable<Cabania> GetByNombre(string nombre)
        {
            try
            {
                return Context.Cabanias.Include("Tipo").Where(cab => cab.Nombre.Contains(nombre))
                    .OrderBy(cab => cab.Nombre).ToList();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        //GETBYTIPO
        public IEnumerable<Cabania> GetByTipo(string tipo)
        {
            try
            {
                return Context.Cabanias.Include("Tipo").Where(cab => cab.Tipo.Nombre == tipo)
                    .OrderBy(cab => cab.Nombre).ToList();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        public IEnumerable<Cabania> GetCabaniasByMonto(double monto)
        {
            try
            {
                return Context.Cabanias.Include("Tipo").Include("Tipo.Costo").Include("Tipo.Descripcion").Where(cab => cab.Tipo.Costo.Valor
                < monto && cab.TieneJacuzzi == true && cab.HabilitadaReservas == true)
                    .OrderBy(cab => cab.Nombre).ToList();
            }
            catch (Exception)
            {
                throw;
                //throw new Exception("Error");
            }
        }

        #region MÉTODOS QUE NO USAMOS
        public void Update(Cabania t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Cabania t)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
