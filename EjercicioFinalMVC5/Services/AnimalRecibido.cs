using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Services
{

    public class Rootobject
    {
        public string odatametadata { get; set; }
        public AnimalRecibido[] value { get; set; }
    }

    public class AnimalRecibido
    {
        [JsonProperty(PropertyName = "AnimalID")]
        public int AnimalRecibidoID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int EspecieID { get; set; }
        public int JaulaID { get; set; }
        public string Imagen { get; set; }
    }
}