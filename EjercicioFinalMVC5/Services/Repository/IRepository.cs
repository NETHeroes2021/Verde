using EjercicioFinalMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFinalMVC5.Services
{
    interface IRepository
    {  
        List<Animal> getAllAnimals();

        List<Animal> getAnimalsIndex();

        Animal getAnimalByID(int id);
        void saveAnimal(Animal animal);
        List<Jaula> getAllJails();
        Jaula getJailsByID(int id);
        List<Especie> getAllEspecies();
        void editAnimal(Animal animal);
        void saveChanges();
        void saveJail(Jaula jaula);
        List<Animal> getAnimalsJail(int id);
        void deleteJail(int id);
        void editJail(Jaula jaula);
        void deleteAnimal(int id);
        void dispose();
        void saveEspecie(Especie especie);
        Especie getEspecieById(int id);
        void deleteEspecie(int id);
        void editEspecie(Especie especie);
         List<Animal> getAnimalByEspecie(int especieID);
         List<Jaula> getJaulasByAnimal(int especieID);
        string dameURL();



    }
}
