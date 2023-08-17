using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IValidable
    {
        #region FIRMAS
        public void Validar(IRepositorioConfiguracion configuracion);
        #endregion
    }
}
