using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC
{
    public interface IGetUnTipoDeCabaniaByNombreUC
    {
        public TipoCabania GetUnTipoCabaniaByNombre(string nombre);
    }
}
