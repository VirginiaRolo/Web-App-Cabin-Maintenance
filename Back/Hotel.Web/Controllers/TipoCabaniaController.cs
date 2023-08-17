using Hotel.LogicaNegocio.Interfaces;
using Hotel.LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.LogicaNegocio.Excepciones;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;

namespace Hotel.Web.Controllers
{
    public class TipoCabaniaController : Controller
    {
        #region ATRIBUTOS
        //Casos de uso
        /*private IRepositorioTipoCabania repositorio;*/
        private IGetTiposDeCabaniaUC getAllTiposUC;
        private ICreateTipoCabaniaUC createTipoCabaniaUC;
        private IGetTiposDeCabaniaByNombreUC getAllTiposByNombreUC;
        private IGetUnTipoDeCabaniaByNombreUC getUnTipoByNombreUC;
        private IDeleteTipoCabaniaUC deleteTipoCabaniaUC;
        private IEditTipoCabaniaUC editTipoCabaniaUC;

        private IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public TipoCabaniaController(
            /*IRepositorioTipoCabania repositorio, */
            IGetTiposDeCabaniaUC getAllTiposUC,
            ICreateTipoCabaniaUC createTipoCabaniaUC,
            IGetTiposDeCabaniaByNombreUC getAllTiposByNombreUC,
            IGetUnTipoDeCabaniaByNombreUC getUnTipoByNombreUC,
            IDeleteTipoCabaniaUC deleteTipoCabaniaUC,
            IEditTipoCabaniaUC editTipoCabaniaUC,
            
            IRepositorioConfiguracion config)
        {
            /*this.repositorio = repositorio;*/
            this.getAllTiposUC = getAllTiposUC;
            this.createTipoCabaniaUC = createTipoCabaniaUC;
            this.getAllTiposByNombreUC = getAllTiposByNombreUC;
            this.getUnTipoByNombreUC = getUnTipoByNombreUC;
            this.deleteTipoCabaniaUC = deleteTipoCabaniaUC;
            this.editTipoCabaniaUC = editTipoCabaniaUC;

            this.config = config;
        }
        #endregion

        //GET
        //Links con funcionalidades de Tipo Cabaña
        public ActionResult HomeTipoCabania()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: Index
        //Listado de todas los tipos de cabañas
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<TipoCabania> ret = getAllTiposUC.GetTiposCabania();

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existe ningún tipo de cabaña aún.";
                    }

                    return View(ret);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }

            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: Create
        //Muestra la vista para crear un tipo de cabaña
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: Create
        //Permite crear un tipo de cabaña
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoCabania tipoCabania)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    createTipoCabaniaUC.CreateTipoCabania(tipoCabania,config);
                    return RedirectToAction(nameof(Index));
                }
                catch (TipoCabaniaException e)
                {
                    ViewBag.Message = e.Message;
                    return View();
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: Edit
        //Muestra la vista para editar un tipo de cabaña
        public ActionResult Edit(string nombre)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                TipoCabania ret = getUnTipoByNombreUC.GetUnTipoCabaniaByNombre(nombre);
                return View(ret);
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        //POST: Edit
        //Permite editar un tipo de cabaña
        // todo: atencion --> no estaria funcionando
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nombre, string descripcion, double costo, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                TipoCabania ret = getUnTipoByNombreUC.GetUnTipoCabaniaByNombre(nombre);
                try
                {
                    //descripcion = "pepitooooooo";
                    //costo = 70;
                    editTipoCabaniaUC.UpdateTipoCabania(nombre, descripcion, costo, config);
                    ViewBag.Message = "Actualizado";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View(ret);
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        //GET: Delete
        //Muestra la vista para borrar un tipo de cabaña
        public ActionResult Delete(string nombre)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                TipoCabania ret = getUnTipoByNombreUC.GetUnTipoCabaniaByNombre(nombre);
                return View(ret);
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: Delete
        //Permite borrar un tipo de cabaña
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string nombre, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                TipoCabania ret = getUnTipoByNombreUC.GetUnTipoCabaniaByNombre(nombre);
                try
                {
                    deleteTipoCabaniaUC.DeleteTipoCabania(nombre);
                    ViewBag.Message = "Eliminada";
                    return RedirectToAction(nameof(Index));
                }
                catch (TipoCabaniaException ie)
                {
                    ViewBag.Message = "Error: " + ie.Message;
                    return View(ret);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error: " + e.Message;
                    return View(ret);
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        //GET: GetByNombre
        //Muestra la vista para buscar un tipo de cabaña por nombre
        public ActionResult GetByNombre()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        // POST
        //Permite buscar un tipo de cabaña por nombre
        [HttpPost]
        public ActionResult GetByNombre(string nombre)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<TipoCabania> ret = getAllTiposByNombreUC.GetTiposCabaniaByNombre(nombre);

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existe ningún tipo de cabaña con ese nombre.";
                    }

                    return View(ret);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error: " + e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        #region MÉTODOS QUE NO SE USAN
        // GET: TipoCabaniaController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        #endregion
    }
}
