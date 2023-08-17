using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAccesoDatos.SqlRepositorios
{
    public class SqlRepositorioUsuario : IRepositorioUsuario
    {
        // Debemos poder acceder al contexto para utilizar los métodos de Sql
        public HotelContext Context { get; set; }

        // Inicializamos el context en la creación de esto (SqlRepositorio... - ... = lo que sea)
        #region CONSTRUCTOR
        public SqlRepositorioUsuario()
        {
            Context = new HotelContext();
        }
        #endregion

        public Usuario Login(string email, string pass)
        {
            try
            {
                return Context.Usuarios.Where(usu => usu.Email == email && usu.Contrasenia == pass).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error");

            }
        }

        public Usuario GetByEmail(string email)
        {
            try
            {
                return Context.Usuarios.Where(usu => usu.Email.ToLower().Trim() == email.ToLower().Trim()).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error");
            }
        }

        #region MÉTODOS QUE NO USAMOS
        public void Create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
