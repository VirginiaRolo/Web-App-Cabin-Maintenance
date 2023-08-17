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
    public class SqlRepositorioMantenimiento : IRepositorioMantenimiento
    {
        // Debemos poder acceder al contexto para utilizar los métodos de Sql
        public HotelContext Context { get; set; }

        // Inicializamos el context en la creación de esto (SqlRepositorio... - ... = lo que sea)
        #region CONSTRUCTOR
        public SqlRepositorioMantenimiento()
        {
            Context = new HotelContext();
        }
        #endregion

        public void CreateConConfig(Mantenimiento mantenimiento, IRepositorioConfiguracion configuracion)
        {
            try
            {
                mantenimiento.Validar(configuracion);
                List<Mantenimiento> ret = GetByIdCabaniaYUnaFecha(mantenimiento.CabaniaId, mantenimiento.Fecha);

                if (VerificarMantenimientosPorDia(ret))
                {
                    Context.Mantenimientos.Add(mantenimiento);
                    Context.SaveChanges();
                }
                else
                {
                    throw new MantenimientoException("No se puede ingresar más de 3 mantenimientos por día.");
                }


            }
            catch (MantenimientoException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }

        public bool VerificarMantenimientosPorDia(List<Mantenimiento> mantXDiaDeUnaCab)
        {

            return (mantXDiaDeUnaCab.Count < 3);
            
        }

        public IEnumerable<Mantenimiento> GetByIdCabaniaYDosFechas(int idCabania, DateTime fecha1, DateTime fecha2)
        {
            SwapeoControlFechas(fecha1, fecha2);

            try
            {
                return Context.Mantenimientos.Include("Cabania").Include("Descripcion").Include("Costo").Where(man => man.Fecha > fecha1 && man.Fecha < fecha2 && man.Cabania.NumeroHabitacion == idCabania).OrderByDescending(man => man.Costo.Valor).ToList();
            }
            catch (Exception)
            {

                //throw new Exception("Error");
                throw;
            }

        }

        public void SwapeoControlFechas(DateTime fecha1, DateTime fecha2)
        {
            DateTime fechaAux;
            if (fecha1 > fecha2)
            {
                fechaAux = fecha1;
                fecha1 = fecha2;
                fecha2 = fechaAux;
            }
        }

        public List<Mantenimiento> GetByIdCabaniaYUnaFecha(int idCabania, DateTime fechaMantenimiento)
        {
            try
            {
                List<Mantenimiento> mantenimientosDeUnaCabXDia = Context.Mantenimientos
                    .Include("Cabania").Where(man =>
                    man.Cabania.NumeroHabitacion == idCabania
                    && man.Fecha.Date == fechaMantenimiento.Date).ToList();
                return mantenimientosDeUnaCabXDia;
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }

        }

        public IEnumerable<Mantenimiento> GetByIdCabania(int idCabania)
        {
            try
            {
                return Context.Mantenimientos.Include("Cabania")
                    .Where(man => man.Cabania.NumeroHabitacion == idCabania)
                    .OrderBy(man => man.Id).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }

        }

        public IEnumerable<Mantenimiento> GetByCapacidadCabaniaRango(int capMin, int capMax, IRepositorioConfiguracion configuracion)
        {
            return Context.Mantenimientos.Include("Cabania")
                .Where(man => man.Cabania.CantMaxPersonas >= capMin && man.Cabania.CantMaxPersonas <= capMax)
                .GroupBy(man => man.NombreFuncionario)
                .Select(x => new Mantenimiento
                {
                    NombreFuncionario = x.Key,
                    Costo = new CostoMantenimiento(x.Sum(man => man.Costo.Valor), configuracion)
                });
                
        }


        #region MÉTODOS QUE NO USAMOS
        //no se usa
        public IEnumerable<Mantenimiento> GetAll()
        {
            try
            {
                return Context.Mantenimientos.Include("Cabania").OrderBy(man => man.Id).ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }


        }

        public void Update(Mantenimiento mantenimiento)
        {
            Context.Mantenimientos.Update(mantenimiento);
        }

        public void Create(Mantenimiento mantenimiento)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Context.Mantenimientos.Remove(GetById(id));
        }

        public Mantenimiento GetById(int id)
        {
            // Despues esto cambia
            return Context.Mantenimientos.ToList()[id];
        }
        #endregion

    }
}
