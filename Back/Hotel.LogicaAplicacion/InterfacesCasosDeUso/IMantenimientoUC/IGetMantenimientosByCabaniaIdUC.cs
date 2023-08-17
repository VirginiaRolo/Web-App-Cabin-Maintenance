﻿using Hotel.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC
{
    public interface IGetMantenimientosByCabaniaIdUC
    {
        public IEnumerable<Mantenimiento> GetMantenimientosByCabaniaId(int idCabania);
    }
}
