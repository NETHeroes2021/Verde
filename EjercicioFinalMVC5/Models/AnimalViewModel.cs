using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Models
{
    public class AnimalViewModel
    {
        public int AnimalID { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> EspecieID { get; set; }
        public Nullable<int> JaulaID { get; set; }
        public byte[] Imagen { get; set; }
        public string DescripcionEspecie { get; set; }
        public string PosicionJaula { get; set; }

    }
}