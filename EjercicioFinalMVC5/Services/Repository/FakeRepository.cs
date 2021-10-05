using EjercicioFinalMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinalMVC5.Services
{
    public class FakeRepository : IRepository
    {

        public List<Animal> animales;
        public List<Jaula> jaulas;
        public List<Especie> especies;
        public Animal animal1;
        public Animal animal2;

        public FakeRepository()
        {
            animales = new List<Animal>();
            jaulas = new List<Jaula>();
            especies = new List<Especie>();

            animal1 = new Animal()
            {

                Nombre = "Egónterator",
                AnimalID = 1,
                JaulaID = 1,
                EspecieID = 1,
                FechaNacimiento = System.DateTime.Now,
                Imagen = ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png")
            };

            animal2 = new Animal()
            {
                Nombre = "Wombat",
                AnimalID = 2,
                JaulaID = 1,
                EspecieID = 1,
                FechaNacimiento = System.DateTime.Now,
                Imagen = ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png"),
            };

            Animal animal3 = new Animal()
            {
                Nombre = "Musaraña",
                AnimalID = 3,
                JaulaID = 1,
                EspecieID = 1,
                FechaNacimiento = System.DateTime.Now,
                Imagen = ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png"),
            };

            Animal animal4 = new Animal()
            {
                Nombre = "kiwi",
                AnimalID = 4,
                JaulaID = 1,
                EspecieID = 1,
                FechaNacimiento = System.DateTime.Now,
                Imagen = ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png"),
            };

            animales.Add(animal1);
            animales.Add(animal2);
            animales.Add(animal3);
            animales.Add(animal4);


            jaulas.Add(new Jaula()
            {
                JaulaID = 1,
                Capacidad = 5,
                Animal = animales,
                PosicionJaula = "Norte"
            });

            especies.Add(new Especie()
            {
                EspecieID = 1,
                Descripcion = "Er animal animaloso"
            });

        }
        public List<Animal> getAnimalByEspecie(int especieID)
        {
            var animalesEspecie = (from x in animales
                                   join p in especies on x.EspecieID equals p.EspecieID
                                   where p.EspecieID == especieID
                                   select p.Descripcion);
            return (List<Animal>)animalesEspecie;
        }
        public List<Jaula> getJaulasByAnimal(int especieID)
        {
            var animalesEspecie = (from x in animales
                                   join p in especies on x.EspecieID equals p.EspecieID
                                   where p.EspecieID == especieID
                                   select x);
            List<Jaula> listaJaulas = new List<Jaula>();
            foreach (var itemAnimal in animalesEspecie)
            {
                foreach (var itemJaula in jaulas)
                {
                    if (itemAnimal.JaulaID == itemJaula.JaulaID)
                    {
                        listaJaulas.Add(itemJaula);
                    }

                }
            }

            return listaJaulas;
        }
        public List<Animal> getAllAnimals()
        {
            return animales;
        }

        public Animal getAnimal()
        {
            return animal1;
        }
        public Animal getAnimalByID(int id)
        {
            var animal = (from x in animales where x.AnimalID == id select x).FirstOrDefault();
            return animal;
        }
        public Jaula getJailsByID(int id)
        {
            var jaula = (from x in jaulas where x.JaulaID == id select x).FirstOrDefault();
            return jaula;
        }

        public void editAnimal(Animal animal)
        {
            foreach (var item in animales)
            {
                if (item.AnimalID == animal.AnimalID)
                {
                    animales.Remove(item);
                    animales.Add(animal);
                    return;
                }
            }
        }

        public void saveAnimal(Animal animal)
        {
            var idMasAlto = animales.Max(x => x.AnimalID);
            animal.AnimalID = idMasAlto + 1;
            animales.Add(animal);
        }

        public List<Jaula> getAllJails()
        {
            return jaulas;
        }
        public void saveEspecie(Especie especie)
        {
            var idMasAlto = especies.Max(x => x.EspecieID);
            especie.EspecieID = idMasAlto + 1;
            especies.Add(especie);
        }
        public Especie getEspecieById(int id)
        {
            var especie = (from x in especies where x.EspecieID == id select x).FirstOrDefault();
            return especie;
        }

        public void deleteEspecie(int id)
        {
            especies.Remove(getEspecieById(id));
        }

        public List<Especie> getAllEspecies()
        {
            return especies;
        }

        public void deleteAnimal(int id)
        {
            animales.Remove(getAnimalByID(id));
        }

        public void dispose()
        {
            //No hace nada
        }

        public void saveChanges()
        {
            //No hace nada
        }

        public void saveJail(Jaula jaula)
        {
            var idMasAlto = jaulas.Max(x => x.JaulaID);
            jaula.JaulaID = idMasAlto + 1;
            jaulas.Add(jaula);
        }

        public List<Animal> getAnimalsJail(int id)
        {
            var animalesJaula = (from x in animales where x.JaulaID == id select x).ToList<Animal>();
            return animalesJaula;
        }

        public void deleteJail(int id)
        {

        }

        public void editJail(Jaula jaula)
        {
            foreach (var item in jaulas)
            {
                if (item.JaulaID == jaula.JaulaID)
                {
                    jaulas.Remove(item);
                    jaulas.Add(jaula);
                    return;
                }
            }
        }

        public void editEspecie(Especie especie)
        {
            foreach (var item in especies)
            {
                if (item.EspecieID == especie.EspecieID)
                {
                    especies.Remove(item);
                    especies.Add(especie);
                    return;
                }
            }
        }
        public string dameURL()
        {
            string url = @"https://zoowebapi.azurewebsites.net/api/Animal?$format=json";
            return url;
        }

        public List<Animal> getAnimalsIndex()
        {
            throw new NotImplementedException();
        }
    }


}
