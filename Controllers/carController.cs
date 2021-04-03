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
    public class carController : Controller
    {
        [Authorize]
        public async Task<ActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (User.Identity.IsAuthenticated)
                {
                    List<carDTO> listaCarros = null;
                    API_Control api = new API_Control();
                    HttpResponseMessage response = await api.GetRequest(Session[Sessions.token].ToString(), serviceUrl.GetAllCars);
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            var jsonCarList = await response.Content.ReadAsStringAsync();
                            listaCarros = JsonConvert.DeserializeObject<List<carDTO>>(jsonCarList);
                            break;
                        case System.Net.HttpStatusCode.NotFound:
                            ModelState.AddModelError("", "No existe una lista de carros en el sistema, contacte al administrador");
                            break;
                    }
                    return View(listaCarros);
                }
                else
                {
                    return View();
                }

            }

        }
    }
}