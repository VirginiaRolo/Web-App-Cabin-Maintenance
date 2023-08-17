using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IRepositorioConfiguracion : IRepositorio<Configuracion>
    {
        public int GetSuperiorByNombre(string nombre);
        public int GetInferiorByNombre(string nombre);
    }
}
