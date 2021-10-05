using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjercicioFinalMVC5.Models;
using System.IO;
using System.Web.Helpers;
using EjercicioFinalMVC5.Services;
using EjercicioFinalMVC5.Services.ID;
using Autofac;
using System.Drawing;
using System.Drawing.Imaging;

namespace EjercicioFinalMVC5.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository repository;
        private Byte[] imagenDefault;
        private ClasePeticion clasePeticion = new ClasePeticion();


    
        public AnimalController()
        {
            using (var scope = AutofacConfig.container.BeginLifetimeScope())
            {
                repository = scope.Resolve<IRepository>();
                
            }
            imagenDefault = ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png");
        }

        // GET: Animal
        public async Task<ActionResult> Index()
        {
            //    ClasePeticion cp = new ClasePeticion();
            //    return View(cp.Carga(repository.dameURL()));



            //var animal = repository.getAllAnimals();
            var animal = repository.getAnimalsIndex();
            foreach (var a in animal)
            {
                if (a.Imagen is null)
                    a.Imagen = imagenDefault;
            }
            return View(animal);
}
        public async Task<ActionResult> Galeria()
        {
            var animal = repository.getAllAnimals();
            foreach (var a in animal)
            {
                if (a.Imagen is null)
                    a.Imagen = imagenDefault;
            }
            return View(animal);
        }

        // GET: Animal
    
        public async Task<ActionResult> IndexTest(List<Animal> animals)
        {
            var animal = animals;

            foreach (var a in animal)
            {
                if (a.Imagen is null)
                    a.Imagen = imagenDefault;
            }

            return View(animal);
        }

        // GET: Animal/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = repository.getAnimalByID((int)id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.EspecieID = new SelectList(repository.getAllEspecies(), "EspecieID", "Descripcion");
            ViewBag.JaulaID = new SelectList(repository.getAllJails(), "JaulaID", "JaulaID");
            return View();
        }

        // POST: Animal/Create
        //patata
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AnimalID,Nombre,FechaNacimiento,EspecieID,JaulaID,Imagen")] Animal animal)
        {

            HttpPostedFileBase file = Request.Files["Image"];
            if (file.FileName.Equals(""))
            {
                animal.Imagen = imagenDefault;
            }
            else
            {
                WebImage image = new WebImage(file.InputStream);
                animal.Imagen = image.GetBytes();
            }

            if (ModelState.IsValid)
            {

                repository.saveAnimal(animal);
                return RedirectToAction("Index");
            }

            ViewBag.EspecieID = new SelectList(repository.getAllEspecies(), "EspecieID", "Descripcion", animal.EspecieID);
            ViewBag.JaulaID = new SelectList(repository.getAllJails(), "JaulaID", "JaulaID", animal.JaulaID);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = repository.getAnimalByID((int)id);
            if (animal.Imagen == null)
            {
                animal.Imagen = imagenDefault;
            }
        
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecieID = new SelectList(repository.getAllEspecies(), "EspecieID", "Descripcion", animal.EspecieID);
            ViewBag.JaulaID = new SelectList(repository.getAllJails(), "JaulaID", "JaulaID", animal.JaulaID);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AnimalID,Nombre,FechaNacimiento,EspecieID,JaulaID,Imagen")] Animal animal)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.ContentLength != 0)
            {
                WebImage image = new WebImage(FileBase.InputStream);
                animal.Imagen = image.GetBytes();
            }
           

            if (ModelState.IsValid)
            {
                repository.editAnimal(animal);
                return RedirectToAction("Index");
            }
            ViewBag.EspecieID = new SelectList(repository.getAllEspecies(), "EspecieID", "Descripcion", animal.EspecieID);
            ViewBag.JaulaID = new SelectList(repository.getAllJails(), "JaulaID", "JaulaID", animal.JaulaID);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = repository.getAnimalByID((int)id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            repository.deleteAnimal(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetImage(Int32 AnimalID)
        {
            //Animal cat = repository.getAnimalByID(AnimalID);
            //if (cat.Imagen != null)
            //{

            //    string type = "image/jpg";
            //    return File(cat.Imagen, type);
            //}
            //else
            //{
            //    return null;
            //}


            byte[] byteImage;
            Animal animal = repository.getAnimalByID(AnimalID);
            if (animal.Imagen != null)
            {
                byteImage = animal.Imagen;
            }
            else
            {
                byteImage = imagenDefault;
            }
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/png");
        }





    }
}
