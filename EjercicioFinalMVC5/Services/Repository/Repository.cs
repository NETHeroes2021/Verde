using EjercicioFinalMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using EjercicioFinalMVC5.Services.Deserializadores;
using EjercicioFinalMVC5.Mappers;

namespace EjercicioFinalMVC5.Services.Repository
{
    public class Repository : IRepository
    {
        private ZooEntities db;
        private ClasePeticion clasePeticion;

        public Repository()
        {
            db = new ZooEntities();
            clasePeticion = new ClasePeticion();
        }

        public List<Animal> getAllAnimals()
        {
            var url = "https://zoowebapi.azurewebsites.net/api/Animal";
            var respuesta = clasePeticion.RealizarPeticion(url);
            return DeserializadorAnimales.deserializa(respuesta);
        }

        public Animal getAnimalByID(int id)
        {
            var url = "https://zoowebapi.azurewebsites.net/api/Animal/" + id;
            var respuesta = clasePeticion.RealizarPeticion(url);
            return DeserializadorAnimales.deserializa(respuesta)[0];
        }

        public List<Jaula> getJails()
        {
            throw new NotImplementedException();
        }

        public Jaula getJailsByID(int id)
        {
            var url = "https://zoowebapi.azurewebsites.net/api/Jaula/" + id;
            var respuesta = clasePeticion.RealizarPeticion(url);
            return DeserializadorJaulas.deserializa(respuesta)[0];
        }
        public List<Animal> getAnimalByEspecie(int especieID)
        {
            var animalesEspecie = (from x in db.Animal
                                   join p in db.Especie on x.EspecieID equals p.EspecieID
                                   where p.EspecieID == especieID
                                   select p.Descripcion);
            return (List<Animal>)animalesEspecie;
        }
        //public List<Animal> getAnimalByEspecie(int especieID)
        //{
        //    var animalesEspecie = (from x in db.Animal
        //                           join p in db.Especie on x.EspecieID equals p.EspecieID
        //                           where p.EspecieID == especieID
        //                           select p.Descripcion);
        //    return (List<Animal>)animalesEspecie;
        //}

        public void saveAnimal(Animal animal)
        {
            db.Animal.Add(animal);
            db.SaveChangesAsync();
        }

        public List<Jaula> getAllJails()
        {
            var url = "https://zoowebapi.azurewebsites.net/api/Jaula";
            var respuesta = clasePeticion.RealizarPeticion(url);
            return DeserializadorJaulas.deserializa(respuesta);
        }

        public List<Especie> getAllEspecies()
        {
            var url = "https://zoowebapi.azurewebsites.net/api/Especie";
            var respuesta = clasePeticion.RealizarPeticion(url);
            return DeserializadorEspecies.deserializa(respuesta);
        }

        public void editAnimal(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

        public void deleteAnimal(int id)
        {
            Animal animal = db.Animal.Find(id);
            db.Animal.Remove(animal);
            db.SaveChangesAsync();
        }

        public void saveChanges()
        {
            db.SaveChanges();
        }

        public void saveJail(Jaula jaula)
        {
            db.Jaula.Add(jaula);
            db.SaveChangesAsync();
        }

        public void editJail(Jaula jaula)
        {
            db.Entry(jaula).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

        //public List<AnimalViewModel> getAnimalsIndex()
        //{
        //    var animalesViewModel = new List<AnimalViewModel>();


        //    var animales = getAllAnimals();
        //    var especies = getAllEspecies();
        //    var jaulas = getAllJails();

        //    foreach (var animal in animales)
        //    {
        //        var jaula = (from jaulaActual in jaulas where animal.JaulaID == jaulaActual.JaulaID select jaulaActual).FirstOrDefault();
        //        var especie = (from especieActual in especies where animal.JaulaID == especieActual.EspecieID select especieActual).FirstOrDefault();
        //        animalesViewModel.Add(AnimalViewModelFactory.dameAnimal(animal, jaula, especie));
        //    }
        //    return animalesViewModel;
        //}

        public List<Animal> getAnimalsIndex()
        {
            var animales = getAllAnimals();
            var especies = getAllEspecies();
            var jaulas = getAllJails();

            foreach (var animal in animales)
            {
                var jaula = (from jaulaActual in jaulas where animal.JaulaID == jaulaActual.JaulaID select jaulaActual).FirstOrDefault();
                var especie = (from especieActual in especies where animal.EspecieID == especieActual.EspecieID select especieActual).FirstOrDefault();
                animal.Especie = especie;
                animal.Jaula = jaula;
            }

            return animales;
        }

        public List<Animal> getAnimalsJail(int id)
        {
            var url = "https://zoowebapi.azurewebsites.net/api/Animal";
            var respuesta = clasePeticion.RealizarPeticion(url);
            var animales = DeserializadorAnimales.deserializa(respuesta);
            var animalesJaula = (from animal in animales where animal.JaulaID == id select animal).ToList();
            return animalesJaula;
                         
        }
        public void deleteJail(int id)
        {
            Jaula jaula = db.Jaula.Find(id);
            db.Jaula.Remove(jaula);
            db.SaveChangesAsync();
        }

        public void dispose()
        {
            //db.Dispose();
        }

        public void saveEspecie(Especie especie)
        {
            db.Especie.Add(especie);
            db.SaveChangesAsync();
        }

        public Especie getEspecieById(int id)
        {

            Especie especie = db.Especie.Find(id);
            return especie;
        }

        public void deleteEspecie(int id)
        {
            Especie especie = db.Especie.Find(id);
            db.Especie.Remove(especie);
            db.SaveChangesAsync();
        }

        public void editEspecie(Especie especie)
        {
            db.Entry(especie).State = EntityState.Modified;
            db.SaveChangesAsync();
        }
        public List<Jaula> getJaulasByAnimal(int especieID)
        {
            var animalesEspecie = (from x in db.Animal
                                   join p in db.Especie on x.EspecieID equals p.EspecieID
                                   where p.EspecieID == especieID
                                   select x);

            var listaJaulas = (from x in db.Jaula
                               join p in animalesEspecie on x.JaulaID equals p.JaulaID
                               select x).Distinct();           

            return listaJaulas.ToList();

        }
        public string dameURL()
        {
            string url = @"https://zoowebapi.azurewebsites.net/api/Animal";
            return url;
        }    

    }
}