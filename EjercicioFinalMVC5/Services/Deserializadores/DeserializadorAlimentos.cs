using EjercicioFinalMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Services.Deserializadores
{
    public class DeserializadorAlimentos
    {
        public static List<Alimento> deserializa(string json)
        {
            if (json.Equals("Servicio no accesible"))
            {
                StreamReader sr = new StreamReader(@".\Files\Alimentos.txt");
                try
                {
                    var elementosSerializados = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Alimento>>(elementosSerializados);
                }
                finally
                {
                    sr.Close();
                }
            }
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Files\Alimentos.txt", json);
            return JsonConvert.DeserializeObject<List<Alimento>>(json);
        }

    }
}