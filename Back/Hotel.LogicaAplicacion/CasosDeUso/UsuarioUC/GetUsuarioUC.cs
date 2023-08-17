using DTOs;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IUsuarioUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.LogicaAplicacion.CasosDeUso.UsuarioUC
{
    public class GetUsuarioUC : IGetUsuarioUC
    {
        public IRepositorioUsuario repo;

        public GetUsuarioUC(IRepositorioUsuario repositorioUsuario)
        {
            repo = repositorioUsuario;
        }

        public DTOs.UsuarioDto GetUsuario(UsuarioDto usuario)
        {
            try
            {
                UsuarioDto usuarioDto = new UsuarioDto();
                Usuario user = repo.GetByEmail(usuario.Email);

                if (user == null || usuario.Password != user.Contrasenia)
                {
                    throw new Exception("Datos Incorrectos");
                }

                usuarioDto.Email = user.Email;
                usuarioDto.Password = user.Contrasenia;

                return usuarioDto;
            }
            catch (UsuarioException ex)
            {
                throw ex;
            }
            catch(Exception e) 
            {
                throw e;
            }


        }
    }
}
