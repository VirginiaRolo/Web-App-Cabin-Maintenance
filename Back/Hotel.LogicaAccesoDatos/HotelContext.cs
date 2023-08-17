using Hotel.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAccesoDatos
{
    public class HotelContext : DbContext
    {
        #region DBSETS
        //CABANIAS
        public DbSet<Cabania> Cabanias { get; set; }
        //TIPOSCABANIAS
        public DbSet<TipoCabania> TiposCabanias { get; set; }
        //MANTENIMIENTOS
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        //USUARIOS
        public DbSet<Usuario> Usuarios { get; set; }
        //USUARIOS --> FUNCIONARIOS
        public DbSet<Funcionario> Funcionarios { get; set; }
        //CONFIGURACIONES
        public DbSet<Configuracion> Configuraciones { get; set; }
        #endregion

        #region CONEXIÓN A LA BASE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer
                (
                @"SERVER=(localdb)\MSSQLLocalDB;
                  DATABASE=HotelCabaniasObligatorioP3;
                  INTEGRATED SECURITY=true;"
                );
        }
        #endregion
    }
}
