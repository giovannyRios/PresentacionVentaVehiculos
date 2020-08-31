using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebVentaVehiculos.Classes;
using Newtonsoft.Json;
using ventaVehiculosModels.Models;
using ventaVehiculosModels.Models.DTOs;


namespace WebVentaVehiculos.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Metodo que recibe la petición inicial de carga de la pagina para retornar a la accion de login
        /// No permite almacenamiento en cache
        /// </summary>
        /// <param name="URL"></param>
        /// <returns>retorno hacia action del login</returns>
        [AllowAnonymous]
        [OutputCache(CacheProfile = "NoCache")]
        public ActionResult Login(String URL)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Url = URL;
            return View();
        }


        [Authorize]
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Metodo que permite la autenticacion
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Login(dateUsersModels ObjUser, string Url)
        {
            if (!ModelState.IsValid)
            {
                return View(ObjUser);
            }

            API_Control Service = new API_Control();

            HttpResponseMessage response = await Service.ApiLogin(ObjUser);

            if (response != null)
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NoContent:
                        ModelState.AddModelError("", "El usuario no se encuentra registrado en la aplicación");
                        return View(ObjUser);

                    case System.Net.HttpStatusCode.Unauthorized:
                        ModelState.AddModelError("", "No esta  autorizado para ingreso en la aplicación");
                        return View(ObjUser);

                    case System.Net.HttpStatusCode.OK:
                        var jsonUser = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        List<loginUserDTO> logueado = JsonConvert.DeserializeObject<List<loginUserDTO>>(jsonUser);
                        if (logueado.First()._IsActive == false)
                        {
                            ModelState.AddModelError("", "El usuario no se encuentra activo");
                            return View(ObjUser);
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(logueado.First()._UserStr, false);
                            Session["USER"] = logueado.First()._UserStr;
                            HttpHeaders headers = response.Headers;
                            IEnumerable<string> values;

                            if (headers.TryGetValues("token", out values))
                            {
                                Session["Token"] = values.First();
                            }

                            return RedirectToLocal(Url);
                        }

                    default:
                        ModelState.AddModelError("","Ha ocurrido un error en la autenticación, contacte al administrador");
                        return View();
                }
            }
            else
            {
                return View();
            }
        }

        private ActionResult RedirectToLocal(string UrlDireccionamiento)
        {
            if (Url.IsLocalUrl(UrlDireccionamiento))
            {
                Redirect(UrlDireccionamiento);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}