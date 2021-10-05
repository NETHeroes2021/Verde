using EjercicioFinalMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace EjercicioFinalMVC5.Services
{
    public class ClasePeticion
    {
        public string RealizarPeticion(string url) 
        {
            HttpClient miCliente =  HttpClientFactory.Create();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpResponseMessage response = miCliente.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                   return response.Content.ReadAsStringAsync().Result; 
                }
                else
                {
                    return "Servicio no accesible";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error en deserializacion");
            }
        }
    }
}