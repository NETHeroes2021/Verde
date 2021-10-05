using EjercicioFinalMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EjercicioFinalMVC5.Services
{
    public class ClasePeticion
    {

        public AnimalRecibido[] Carga(string url)

        {
            HttpClient miCliente = new HttpClient();
            try
            {
                HttpResponseMessage response = miCliente.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var miFeed = JsonConvert.DeserializeObject<Rootobject>(result);
                    var ColeccionAnimales = miFeed.value;
                    return ColeccionAnimales;
                }
                else
                {
                    throw new Exception("El servicio no está online");
                }

            }
            catch (Exception e)
            {

                throw new Exception("Error en deserializacion");
            }

        }

    }
}