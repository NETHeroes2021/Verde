using EjercicioFinalMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Services.Deserializadores
{
    public class DeserializadorEspecies
    {
        public static List<Especie> deserializa(string json)
        {
            if (json.Equals("Servicio no accesible"))
            {
                StreamReader sr = new StreamReader(@".\Files\Especies.txt");
                try
                {
                    var elementosSerializados = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Especie>>(elementosSerializados);
                }
                finally
                {
                   sr.Close(); 
                }
            }
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory  + @"\Files\Especies.txt", json);
            return JsonConvert.DeserializeObject<List<Especie>>(json);
        }
    }
}