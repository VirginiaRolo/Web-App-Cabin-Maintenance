using Hotel.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.Web.Controllers
{
    public class CabaniaController : Controller
    {
        #region ATRIBUTOS
        private string localHost;
        private HttpClient cliente;
        private IWebHostEnvironment webHostEnvironment;
        #endregion

        #region CONSTRUCTOR
        public CabaniaController(IWebHostEnvironment webHostEnvironment)
        {
            localHost = "https://localhost:7100";
            cliente = new HttpClient();
            this.webHostEnvironment = webHostEnvironment;
        }
        #endregion

        //GET
        //Links con funcionalidades de Cabaña
        public ActionResult HomeCabania()
        {
            return View();
        }

        //GET: Index
        //Listado de todas las cabañas
        public ActionResult Index()
        {
            Uri uri = new Uri(localHost + "/api/Cabanias");
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();

            Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

            CabaniaModel[] listaCabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

            return View(listaCabanias);
        }

        // GET: Create
        //Muestra la vista para crear una cabaña
        public ActionResult Create()
        {
            // ------ LLAMADA A TIPOS DE CABANIAS --------
            /******************* HEADERS *******************/
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

            Uri uri2 = new Uri(localHost + "/api/TipoCabanias");
            HttpRequestMessage solicitud2 = new HttpRequestMessage(HttpMethod.Get, uri2);

            /******************* CONTENIDO O BODY ********************/
            //string json = JsonConvert.SerializeObject(cabania);
            //HttpContent contenido =
            //new StringContent(json, Encoding.UTF8, "application/json");
            //solicitud.Content = contenido;
            /*************** END CONTENIDO O BODY ********************/

            Task<HttpResponseMessage> respuesta2 = cliente.SendAsync(solicitud2);
            respuesta2.Wait();

            Console.WriteLine(respuesta2.Result.StatusCode.ToString());

            Console.WriteLine(respuesta2.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
            Task<string> response2 = respuesta2.Result.Content.ReadAsStringAsync();

            TipoCabaniaModel[] listaTipos = JsonConvert.DeserializeObject<TipoCabaniaModel[]>(response2.Result);

            ViewBag.listaTipoCabanias = listaTipos;
            return View();
        }
        //POST: Create
        //Permite crear una cabaña
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CabaniaModel cabania, IFormFile imagen)
        {
            try
            {
                GuardarImagen(imagen, cabania);

                // ------ LLAMADA A CABANIAS --------
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Cabanias");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                /******************* CONTENIDO O BODY ********************/
                string json = JsonConvert.SerializeObject(cabania);
                HttpContent contenido =
                new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = response.Result;
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Create", new { error = e.Message });
            }
        }

        //Método para guardar la imágen
        private void GuardarImagen(IFormFile imagen, CabaniaModel cabania)
        {
            if (imagen == null || cabania == null)
            {
                throw new Exception("Datos incorrectos");
            }

            string rutaFisicaWwwRoot = webHostEnvironment.WebRootPath;
            string extension = imagen.FileName.Split(".").Last();
            string nombreImagen = cabania.Nombre + "_001." + extension;

            string rutaFisicaImgsCabanias = Path.Combine(rutaFisicaWwwRoot, "imgs", "Cabanias", nombreImagen);

            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaImgsCabanias, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    imagen.CopyTo(f);
                }

                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                cabania.Foto = nombreImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GET: GetCabaniasByCantMaxPersonas
        //Muestra la vista para buscar una cabaña por cantidad máxima de personas
        public ActionResult GetCabaniasByCantMaxPersonas()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetCabaniasByCantMaxPersonas(int cantidad)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Cabanias/CantPersonas/" + cantidad);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(equipo);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[] listaCabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

                return View(listaCabanias);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: GetCabaniasHabilitadasReserva
        //Listado de todas las cabañas habilitadas para reservas
        //[ValidateAntiForgeryToken]
        public ActionResult GetCabaniasHabilitadasReserva()
        {
            HttpClient cliente = new HttpClient();
            Uri uri = new Uri(localHost + "/api/Cabanias/Habilitadas");
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();

            Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

            CabaniaModel[] listaCabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

            return View(listaCabanias);
        }

        //GET: GetCabaniasByNombre
        //Muestra la vista para buscar una cabaña por nombre
        public ActionResult GetCabaniasByNombre()
        {
            return View();
        }

        //POST: GetCabaniasByNombre
        //Listado de cabañas que coincidan con un nombre
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetCabaniasByNombre(string nombre)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Cabanias/Nombre/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(equipo);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[] listaCabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

                return View(listaCabanias);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: GetCabaniasByTipo
        //Muestra la vista para buscar una cabaña por tipo de cabaña
        public ActionResult GetCabaniasByTipo()
        {
            return View();
        }

        //POST: GetCabaniasByTipo
        //Listado de cabañas que coincidan con un tipo de cabaña
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetCabaniasByTipo(string tipo)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Cabanias/Tipo/" + tipo);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(equipo);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[] listaCabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

                return View(listaCabanias);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: GetCabaniasByMonto
        // Listado de cabañas con un costo menor al ingresado
        public ActionResult GetCabaniasByMonto()
        {
            return View();
        }

        //POST: GetCabaniasByMonto
        //Listado de cabañas con un costo menor al ingresado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetCabaniasByMonto(double monto)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Cabanias/Monto/" + monto);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(equipo);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                CabaniaModel[] listaCabanias = JsonConvert.DeserializeObject<CabaniaModel[]>(response.Result);

                return View(listaCabanias);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
