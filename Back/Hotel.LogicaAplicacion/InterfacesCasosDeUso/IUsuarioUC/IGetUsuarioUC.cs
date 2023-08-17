using DTOs;
using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.InterfacesCasosDeUso.IUsuarioUC
{
    public interface IGetUsuarioUC
    {
        public UsuarioDto GetUsuario(UsuarioDto usuario);
    }
}
