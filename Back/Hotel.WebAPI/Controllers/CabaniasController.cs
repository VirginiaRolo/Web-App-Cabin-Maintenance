using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using DTOs;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaAplicacion.CasosDeUso.MantenimientoUC;

namespace Hotel.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CabaniasController : Controller
    {
        #region ATRIBUTOS
        //Casos de uso
        private IGetCabaniasUC getAllCabaniasUC;
        private ICreateCabaniaUC createCabaniaUC;
        private IGetCabaniasByCantMaxPersonasUC getAllCabaniasByCantMaxPersonasUC;
        private IGetCabaniasHabilitadasParaReservaUC getAllCabaniasHabilitadasParaReservaUC;
        private IGetCabaniasByNombreUC getAllCabaniasByNombreUC;
        private IGetCabaniasByTipoUC getAllCabaniasByTipoUC;
        private IGetCabaniasByMontoUC getAllCabaniasByMontoUC;
        private IGetUnaCabaniaByIdUC getUnaCabaniaByIdUC;
        #endregion

        #region CONSTRUCTOR
        public CabaniasController(
            IGetCabaniasUC getAllCabaniasUC,
            ICreateCabaniaUC createCabaniaUC,
            IGetCabaniasByCantMaxPersonasUC getAllCabaniasByCantMaxPersonasUC,
            IGetCabaniasHabilitadasParaReservaUC getAllCabaniasHabilitadasParaReservaUC,
            IGetCabaniasByNombreUC getAllCabaniasByNombreUC,
            IGetCabaniasByTipoUC getAllCabaniasByTipoUC,
            IGetCabaniasByMontoUC getAllCabaniasByMontoUC,
            IGetUnaCabaniaByIdUC getUnaCabaniaByIdUC)
        {
            this.getAllCabaniasUC = getAllCabaniasUC;
            this.createCabaniaUC = createCabaniaUC;
            this.getAllCabaniasByCantMaxPersonasUC = getAllCabaniasByCantMaxPersonasUC;
            this.getAllCabaniasHabilitadasParaReservaUC = getAllCabaniasHabilitadasParaReservaUC;
            this.getAllCabaniasByNombreUC = getAllCabaniasByNombreUC;
            this.getAllCabaniasByTipoUC = getAllCabaniasByTipoUC;
            this.getAllCabaniasByMontoUC = getAllCabaniasByMontoUC;
            this.getUnaCabaniaByIdUC = getUnaCabaniaByIdUC;
        }
        #endregion

        //GET: GetCabanias
        /// <summary>
        /// Listado de todas las cabañas
        /// </summary>
        /// <returns>Retorna listado de todas las cabañas</returns>
        /// <response code="200">Retorna el listado de todas las cabañas</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCabanias()
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = getAllCabaniasUC.GetCabanias();

                if (listaCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaCabanias);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: CreateCabanias
        /// <summary>
        /// Dar de alta una cabaña
        /// </summary>
        /// <returns>Retorna la cabaña creada si se da de alta exitosamente</returns>
        /// <response code="201">Retorna la cabaña creada</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpPost("/api/Cabanias")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateCabanias([FromBody] CabaniaDto cabania)
        {
            try
            {
                createCabaniaUC.CreateCabania(cabania);

                return Created(new Uri("http://localhost:1234/api/Cabanias"), cabania);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetCabaniasByCantidadPersonas
        /// <summary>
        /// Listado de cabañas buscar por cantidad máxima de personas
        /// </summary>
        /// /// <param name="cantidad">Numero de cantidad de personas</param>
        /// <returns>Retorna listado de todas las cabañas que aceptan el parámetro ingresado, o más, como cantidad de personas</returns>
        /// <response code="200">Retorna el listado de todas las cabañas por cantidad maxima de personas</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias/CantPersonas/{cantidad}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCabaniasByCantidadPersonas(int cantidad)
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = getAllCabaniasByCantMaxPersonasUC.GetCabaniasByCantMaxPersonas(cantidad);

                if (listaCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaCabanias);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetCabaniasHabilitadasReserva
        /// <summary>
        /// Listado de cabañas habilitadas para reserva
        /// </summary>
        /// <returns>Retorna listado de todas las cabañas habilitadas para reservas</returns>
        /// <response code="200">Retorna el listado de todas las cabañas habilitadas para reserva</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias/Habilitadas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCabaniasHabilitadasReserva()
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = getAllCabaniasHabilitadasParaReservaUC.GetCabaniasHabilitadasParaReserva();

                if (listaCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaCabanias);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetCabaniasByNombre
        /// <summary>
        /// Listado de cabañas dado un nombre
        /// </summary>
        /// <param name="nombre">Texto que contiene el nombre de la cabaña a buscar</param>
        /// <returns>Retorna listado de todas las cabañas que contienen en su nombre el parametro ingresado</returns>
        /// <response code="200">Retorna el listado de todas las cabañas dado un nombre</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias/Nombre/{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public IActionResult GetCabaniasByNombre(string nombre)
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = getAllCabaniasByNombreUC.GetCabaniasByNombre(nombre);

                if (listaCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaCabanias);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   

        //GET: GetCabaniasByTipoCabania
        /// <summary>
        /// Listado de cabañas buscar por tipo de cabaña
        /// </summary>
        /// <param name="tipo">Texto que contiene el tipo de la cabaña a buscar</param>
        /// <returns>Retorna listado de todas las cabañas del tipo ingresado por parámetro</returns>
        /// <response code="200">Retorna el listado de todas las cabañas dado un tipo</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias/Tipo/{tipo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCabaniasByTipoCabania(string tipo)
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = getAllCabaniasByTipoUC.GetCabaniasByTipo(tipo);

                if (listaCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaCabanias);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetCabaniasByMonto
        /// <summary>
        /// Listado de cabañas con un costo menor al ingresado por parámetros
        /// </summary>
        /// <param name="monto">Numero que representa el monto por persona por dia</param>
        /// <returns>Retorna un listado de cabañas con un costo menor al ingresado por parámetros</returns>
        /// <response code="200">Retorna un listado de cabañas con un costo menor al ingresado por parámetros</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias/Monto/{monto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCabaniasByMonto(double monto)
        {
            try
            {
                IEnumerable<Cabania> listaCabanias = getAllCabaniasByMontoUC.GetCabaniasByMonto(monto);

                if (listaCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaCabanias);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetUnaCabaniaById
        /// <summary>
        /// Busqueda de una cabaña por Id
        /// </summary>
        /// <param name="idCabania">Numero que representa el numero de habitación de la cabaña</param>
        /// <returns>Retorna la cabaña que coincide con el id ingresado por parámetros</returns>
        /// <response code="200">Retorna la cabaña que coincide con el id ingresado por parámetros</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/Cabanias/Id/{idCabania}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUnaCabaniaById(int idCabania)
        {
            try
            {
                Cabania unaCabania = getUnaCabaniaByIdUC.GetUnaCabaniaById(idCabania);

                if (unaCabania == null)
                {
                    return NotFound();
                }

                return Ok(unaCabania);
            }
            catch (CabaniaException ce)
            {
                return BadRequest(ce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
