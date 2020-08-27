﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using ventaVehiculosModels.Models;


namespace WebVentaVehiculos.Classes
{
    public class API_Control
    {
        string baseUrl = "https://localhost:44365/";

        /// <summary>
        /// Metodo de autenticacion que recibe objeto modelo con los datos de autenticacion
        /// </summary>
        /// <param name="userDate"></param>
        /// <returns>HttpResponseMenssaje con respuesta de acceso a la aplicacion</returns>
        public  async System.Threading.Tasks.Task<HttpResponseMessage>ApiLogin(dateUsersModels userDate)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(userDate), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(serviceUrl.loginService, content);
                    return response;
                }
            }
            catch (Exception e)
            {
                //Se debe crear un metodo para registrar en log la excepcion
                throw e;
            }
        }

        /// <summary>
        /// Metodo que permite conexion por medio de PostRequest 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <param name="urlApi"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PostRequest(StringContent data, string token, string urlApi)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PostAsync(urlApi,data);
                    return response;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async System.Threading.Tasks.Task<HttpResponseMessage> GetRequest(string token, string urlApi)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(urlApi);
                    return response;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}