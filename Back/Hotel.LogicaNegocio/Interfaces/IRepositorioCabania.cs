using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IRepositorioCabania : IRepositorio<Cabania>
    {
        public void CreateConConfig(Cabania cabania, IRepositorioConfiguracion configuracion);
        public IEnumerable<Cabania> GetByCantMaxPersonas(int numero);
        public IEnumerable<Cabania> GetByHabilitada();
        public IEnumerable<Cabania> GetByNombre(string nombre);
        public IEnumerable<Cabania> GetByTipo(string tipo);
        public IEnumerable<Cabania> GetCabaniasByMonto(double monto);
    }
}
