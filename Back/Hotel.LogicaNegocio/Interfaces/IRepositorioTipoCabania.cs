using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IRepositorioTipoCabania : IRepositorio<TipoCabania>
    {
        public void CreateConConfig(TipoCabania tipoCabania, IRepositorioConfiguracion configuracion);
        public IEnumerable<TipoCabania> GetByNombre(string nombre);
        public bool IsEnUso(TipoCabania tipo);
        public void DeleteTipoCabania(string nombre);
        public TipoCabania GetByNombreTipoCabania(string nombre);
        public void UpdateConConfig(TipoCabania tipo, string nombre, IRepositorioConfiguracion configuracion);
    }
}
