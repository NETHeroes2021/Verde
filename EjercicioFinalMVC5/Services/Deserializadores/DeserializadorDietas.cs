using EjercicioFinalMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Services.Deserializadores
{
    public class DeserializadorDietas
    {
        public static List<Dieta> deserializa(string json)
        {
            if (json.Equals("Servicio no accesible"))
            {
                StreamReader sr = new StreamReader(@".\Files\Dietas.txt");
                try
                {
                    var elementosSerializados = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Dieta>>(elementosSerializados);
                }
                finally
                {
                    sr.Close();
                }
            }
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory  + @"\Files\Dietas.txt", json);
            return JsonConvert.DeserializeObject<List<Dieta>>(json);
        }

    }
}