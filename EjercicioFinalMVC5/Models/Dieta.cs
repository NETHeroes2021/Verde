//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjercicioFinalMVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dieta
    {
        public int ID { get; set; }
        public int AnimalID { get; set; }
        public int AlimentoID { get; set; }
        public Nullable<int> Cantidad { get; set; }
    
        public virtual Alimento Alimento { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
