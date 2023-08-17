using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Excepciones
{
    public class TipoCabaniaException : Exception
    {
        public TipoCabaniaException() { }
        public TipoCabaniaException(string mensaje)
        : base(mensaje) { }
        public TipoCabaniaException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
