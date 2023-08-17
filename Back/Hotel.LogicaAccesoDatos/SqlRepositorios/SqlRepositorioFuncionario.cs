using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAccesoDatos.SqlRepositorios
{
    public class SqlRepositorioFuncionario : IRepositorioUsuario
    {
        // Debemos poder acceder al contexto para utilizar los métodos de Sql
        public HotelContext Context { get; set; }

        // Inicializamos el context en la creación de esto (SqlRepositorio... - ... = lo que sea)
        #region CONSTRUCTOR
        public SqlRepositorioFuncionario()
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

        #region MÉTODOS QUE NO USAMOS
        public void Create(Usuario funcionario)
        {
            // PARA REVISAR
            Context.Funcionarios.Add((Funcionario)funcionario);
        }

        public void Delete(int id)
        {
            // PARA REVISAR
            Context.Funcionarios.Remove((Funcionario)GetById(id));
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Context.Funcionarios;
        }

        public Usuario GetById(int id)
        {
            // Despues esto cambia
            return Context.Funcionarios.ToList()[id];
        }

        public void Update(Usuario funcionario)
        {
            // PARA REVISAR
            Context.Funcionarios.Update((Funcionario)funcionario);
        }

        public Usuario GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
