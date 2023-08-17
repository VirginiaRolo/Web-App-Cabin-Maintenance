using DTOs;
using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC
{
    public interface IGetCabaniasByCantMaxPersonasUC
    {
        public IEnumerable<Cabania> GetCabaniasByCantMaxPersonas(int cantMaxPersonas);
    }
}
