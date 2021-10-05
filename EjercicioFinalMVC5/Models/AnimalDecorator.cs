using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Models
{
    [MetadataType(typeof(AnimalDecorator))]
    public partial class Animal
    {

    }

    public class AnimalDecorator
    {

        public int AnimalID { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Nombre animal:")]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }

        [Required]
        public Nullable<int> EspecieID { get; set; }

        [Required]
        public Nullable<int> JaulaID { get; set; }

        public byte[] Imagen { get; set; }
    }
}