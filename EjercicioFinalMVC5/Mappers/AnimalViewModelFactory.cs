using EjercicioFinalMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Mappers
{
    public static  class AnimalViewModelFactory
    {

        public static AnimalViewModel dameAnimal(Animal animal, Jaula jaula, Especie especie)
        {
            return new AnimalViewModel()
            {
                AnimalID = animal.AnimalID,
                DescripcionEspecie = especie.Descripcion,
                EspecieID = animal.EspecieID,
                FechaNacimiento = animal.FechaNacimiento,
                Imagen = animal.Imagen,
                JaulaID = animal.JaulaID,
                Nombre = animal.Nombre,
                PosicionJaula = jaula.PosicionJaula
            };
        }     
    }
}