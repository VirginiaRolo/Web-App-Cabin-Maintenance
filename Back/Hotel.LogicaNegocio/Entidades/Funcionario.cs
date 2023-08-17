using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Entidades
{
    public class Funcionario : Usuario
    {
        #region PROPERTIES
        #endregion

        #region CONSTRUCTORES
        // Vacío
        public Funcionario() { }

        // Todos los parámetros
        public Funcionario(string email, string contrasenia) : base(email, contrasenia)
        {
        }
        #endregion

        #region MÉTODOS
        #endregion
    }
}
