using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario Login(string email, string pass);
        public Usuario GetByEmail(string email);
    }
}
