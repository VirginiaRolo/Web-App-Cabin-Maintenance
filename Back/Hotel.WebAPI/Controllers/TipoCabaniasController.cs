using DTOs;
using Hotel.LogicaAplicacion.CasosDeUso.CabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
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
    public class TipoCabaniasController : Controller
    {
        #region ATRIBUTOS
        //Casos de uso
        private IGetTiposDeCabaniaUC getAllTiposUC;
        private ICreateTipoCabaniaUC createTipoCabaniaUC;
        private IGetTiposDeCabaniaByNombreUC getAllTiposByNombreUC;
        private IDeleteTipoCabaniaUC deleteTipoCabaniaUC;
        private IEditTipoCabaniaUC editTipoCabaniaUC;
        private IGetUnTipoDeCabaniaByNombreUC getUnTipoDeCabaniaByNombreUC;
        #endregion

        #region CONSTRUCTOR
        public TipoCabaniasController(
            IGetTiposDeCabaniaUC getAllTiposUC,
            ICreateTipoCabaniaUC createTipoCabaniaUC,
            IGetTiposDeCabaniaByNombreUC getAllTiposByNombreUC,
            IDeleteTipoCabaniaUC deleteTipoCabaniaUC,
            IEditTipoCabaniaUC editTipoCabaniaUC,
            IGetUnTipoDeCabaniaByNombreUC getUnTipoDeCabaniaByNombreUC)
        {
            this.getAllTiposUC = getAllTiposUC;
            this.createTipoCabaniaUC = createTipoCabaniaUC;
            this.getAllTiposByNombreUC = getAllTiposByNombreUC;
            this.deleteTipoCabaniaUC = deleteTipoCabaniaUC;
            this.editTipoCabaniaUC = editTipoCabaniaUC;
            this.getUnTipoDeCabaniaByNombreUC = getUnTipoDeCabaniaByNombreUC;
        }
        #endregion

        //GET: GetTipoCabanias
        /// <summary>
        /// Listado de todos los tipos de cabañas
        /// </summary>
        /// <returns>Retorna listado de todos los tipos de cabañas</returns>
        /// /// <response code="200">Retorna el listado de todos los tipos de cabañas</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/TipoCabanias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetTipoCabanias()
        {
            try
            {
                IEnumerable<TipoCabania> listaTipoCabanias = getAllTiposUC.GetTiposCabania();

                if (listaTipoCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaTipoCabanias);
            }
            catch (TipoCabaniaException tce)
            {
                return BadRequest(tce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: CreateTipoCabanias
        /// <summary>
        /// Dar de alta un tipo de cabaña
        /// </summary>
        /// <returns>Retorna el tipo de cabaña creado si se da de alta exitosamente</returns>
        /// <response code="201">Retorna el tipo de cabaña creada</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpPost("/api/TipoCabanias")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateTipoCabanias([FromBody] TipoCabaniaDto tipoCabania)
        {
            try
            {
                createTipoCabaniaUC.CreateTipoCabania(tipoCabania);

                return Created(new Uri("http://localhost:1234/api/TipoCabanias"), tipoCabania);
            }
            catch (TipoCabaniaException tce)
            {
                return BadRequest(tce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: EditTipoCabanias
        /// <summary>
        /// Editar un tipo de cabaña
        /// </summary>
        /// <returns>Retorna el tipo de cabaña editado</returns>
        /// <response code="200">Retorna el tipo de cabaña editado</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        /// <returns>Retorna el listado de todos los tipos de cabañas al editarse exitosamente un tipo de cabaña</returns>
        [HttpPut("/api/TipoCabanias/{nombre}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult EditTipoCabanias([FromBody] TipoCabaniaEditDto tipoCabania, string nombre)
        {
            try
            {
                editTipoCabaniaUC.UpdateTipoCabania(tipoCabania, nombre);

                return Ok(tipoCabania);
            }
            catch (TipoCabaniaException tce)
            {
                return BadRequest(tce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetTipoCabaniasByNombre
        /// <summary>
        /// Listado de los tipos de cabañas dado un nombre
        /// </summary>
        /// <param name="nombre">Texto que contiene el nombre del tipo de la cabaña a buscar</param>
        /// <returns>Retorna listado de todos los tipos de cabañas que contienen en su nombre el parametro ingresado</returns>
        /// <response code="200">Retorna el listado de todos los tipos de cabañas dado un nombre</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/TipoCabanias/Nombre/{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public IActionResult GetTipoCabaniasByNombre(string nombre)
        {
            try
            {
                IEnumerable<TipoCabania> listaTipoCabanias = getAllTiposByNombreUC.GetTiposCabaniaByNombre(nombre);

                if (listaTipoCabanias.IsNullOrEmpty())
                {
                    return NotFound();
                }

                return Ok(listaTipoCabanias);
            }
            catch (TipoCabaniaException tce)
            {
                return BadRequest(tce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: GetUnTipoCabaniasByNombre
        /// <summary>
        /// Un tipo de cabaña dado un nombre
        /// </summary>
        /// <param name="nombre">Texto que contiene el nombre del tipo de la cabaña a buscar</param>
        /// <returns>Retorna un tipo de cabaña que contiene en su nombre el parametro ingresado</returns>
        /// <response code="200">Retorna un tipo de cabaña que contiene en su nombre el parametro ingresado</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpGet("/api/TipoCabanias/UnNombre/{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public IActionResult GetUnTipoCabaniasByNombre(string nombre)
        {
            try
            {
                TipoCabania tipoCabania = getUnTipoDeCabaniaByNombreUC.GetUnTipoCabaniaByNombre(nombre);

                if (tipoCabania == null)
                {
                    return NotFound();
                }

                return Ok(tipoCabania);
            }
            catch (TipoCabaniaException tce)
            {
                return BadRequest(tce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: DeleteTipoCabanias
        /// <summary>
        /// Dar de baja un tipo de cabaña
        /// </summary>
        /// /// <param name="nombre">Texto que contiene el nombre del tipo de la cabaña a eliminar</param>
        /// <returns>Retorna el listado de todos los tipos de cabañas al darse de alta exitosamente un tipo de cabaña</returns>
        /// <response code="204">Retorna que se borro el tipo de cabaña</response>
        /// <response code="400">Solicitud incorrecta</response>
        /// <response code="404">El objeto buscado no se encuentra</response>
        /// <response code="401">No esta autorizado para ver este contenido</response>
        [HttpDelete("/api/TipoCabanias/{nombre}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteTipoCabanias(string nombre)
        {
            try
            {
                deleteTipoCabaniaUC.DeleteTipoCabania(nombre);

                return NoContent();
            }
            catch (TipoCabaniaException tce)
            {
                return BadRequest(tce.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
    }
}
