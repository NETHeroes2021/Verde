using EjercicioFinalMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Services.Deserializadores
{
    public static class DeserializadorAnimales
    {

        public static List<Animal> deserializa(string json)
        {
            if (json.Equals("Servicio no accesible"))
            {
                StreamReader sr = new StreamReader(@".\Files\Animales.txt");
                try
                {
                    var elementosSerializados = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Animal>>(elementosSerializados);
                }
                finally
                {
                    sr.Close();
                }
            }
           
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Files\Animales.txt");
            try
            {
                sw.Write(json);
                return JsonConvert.DeserializeObject<List<Animal>>(json);
            }
            finally
            {
                sw.Close();
            }
            
            
            
        }


    }
}