using DTOs;
using Hotel.LogicaAplicacion.CasosDeUso.TipoCabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MantenimientosController : Controller
    {
        #region ATRIBUTOS
        //Casos de uso
        private ICreateMantenimientoUC createMantenimientoUC;
        private IGetMantenimientosByCabaniaIdUC getAllMantenimientosByCabaniaIdUC;
        private IGetMantenimientosByCabaniaIdYDosFechasUC getAllMantenimientosByCabaniaIdYDosFechasUC;

        private IGetUnaCabaniaByIdUC getUnaCabaniaByIdUC;
        private IGetMantenimientosByCabaniaRangoUC getMantenimientosByCabaniaRangoUC;
        #endregion

        #region CONSTRUCTOR
        public MantenimientosController(
            ICreateMantenimientoUC createMantenimientoUC,
            IGetMantenimientosByCabaniaIdUC getAllMantenimientosByCabaniaIdUC,
            IGetMantenimientosByCabaniaIdYDosFechasUC getAllMantenimientosByCabaniaIdYDosFechasUC,

            IGetUnaCabaniaByIdUC getUnaCabaniaByIdUC,
            IGetMantenimientosByCabaniaRangoUC getMantenimientosByCabaniaRangoUC)
        {
            this.createMantenimientoUC = createMantenimientoUC;
            this.getAllMantenimientosByCabaniaIdUC = getAllMantenimientosByCabaniaIdUC;
            this.getAllMantenimientosByCabaniaIdYDosFechasUC = getAllMantenimientosByCabaniaIdYDosFechasUC;

            this.getUnaCabaniaByIdUC = getUnaCabaniaByIdUC;
            this.getMantenimientosByCabaniaRangoUC = getMantenimientosByCabaniaRangoUC;
        }
        #endregion

        //GET: GetMantenimientosDeCabania
        /// <summary>
        /// Listado de mantenimientos por Id de cabaña
        /// </summary>
        /// <param name="idCabania">Texto que contiene el tipo de la cabaña a buscar</param>
        /// <returns>Retorna listado de todos los mantenimientos realizados a una cabaña</returns>
        /// <response code="200">Retorna el listado de mantenimientos por id de cabaña</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Mantenimientos/{idCabania}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetMantenimientosDeCabania(int idCabania)
        {
            try
            {
                IEnumerable<Mantenimiento> listaMantenimientos = getAllMantenimientosByCabaniaIdUC.GetMantenimientosByCabaniaId(idCabania);

                if (listaMantenimientos.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaMantenimientos);
            }
            catch (MantenimientoException me)
            {
                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: CreateMantenimientos
        /// <summary>
        /// Dar de alta un mantenimiento
        /// </summary>
        /// <returns>Retorna el mantenimiento creado si se da de alta exitosamente</returns>
        /// <response code="201">Retorna el mantenimiento creada</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpPost("/api/Mantenimientos")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateMantenimientos([FromBody] MantenimientoDto mantenimiento)
        {
            try
            {
                createMantenimientoUC.CreateMantenimiento(mantenimiento);

                return Created(new Uri("http://localhost:1234/api/Mantenimientos"), mantenimiento);
            }
            catch (MantenimientoException me)
            {
                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetMantenimientosByFechas
        /// <summary>
        /// Listado de mantenimientos por Id de cabaña entre dos fechas
        /// </summary>
        /// <param name="idCabania">Texto que contiene el tipo de la cabaña a buscar</param>
        /// <param name="fecha1">Fecha desde</param>
        /// <param name="fecha2">Fecha hasta</param>
        /// <returns>Retorna listado de todos los mantenimientos realizados a una cabaña entre dos fechas ingresadas por parámetro</returns>
        /// <response code="200">Retorna listado de todos los mantenimientos realizados a una cabaña entre dos fechas</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        //[HttpGet("/api/Mantenimientos/{idCabania}/fecha1/{fecha1}/fecha2/{fecha2}")]
        [HttpGet("/api/Mantenimientos/{idCabania}/{fecha1}/{fecha2}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetMantenimientosByFechas(int idCabania, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                IEnumerable<Mantenimiento> listaMantenimientos =
                    getAllMantenimientosByCabaniaIdYDosFechasUC.GetMantenimientosByCabaniaIdYDosFechas
                    (idCabania, fecha1, fecha2);

                if (listaMantenimientos.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaMantenimientos);
            }
            catch (MantenimientoException me)
            {
                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetMantenimientosByCabaniaRangoUC
        /// <summary>
        /// Listado de mantenimientos realizados a las cabañas con una capacidad comprendida entre los valores ingresados
        /// </summary>
        /// <param name="capMin">Numero que representa la capacidad mínima de la cabaña</param>
        /// <param name="capMax">Numero que representa la capacidad máxima de la cabaña</param>
        /// <returns>Retorna listado de todos los mantenimientos realizados a una cabaña agrupados por nombre de la persona que realizó el mantenimiento y el monto total de los mantenimientos que realizó</returns>
        /// <response code="200">Retorna listado de todos los mantenimientos realizados a una cabaña agrupados por nombre de la persona que realizó el mantenimiento y el monto total de los mantenimientos que realizó</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Mantenimientos/CapMin/{capMin}/CapMax/{capMax}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetMantenimientosByCabaniaRangoUC(int capMin, int capMax)
        {
            try
            {
                IEnumerable<Mantenimiento> listaMantenimientos = getMantenimientosByCabaniaRangoUC.GetByCapacidadCabaniaRango(capMin, capMax);

                if (listaMantenimientos.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaMantenimientos);
            }
            catch (MantenimientoException me)
            {
                return BadRequest(me.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
