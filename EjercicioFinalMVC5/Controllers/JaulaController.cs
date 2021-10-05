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
using System.Collections;
using EjercicioFinalMVC5.Services;
using EjercicioFinalMVC5.Services.ID;
using Autofac;

namespace EjercicioFinalMVC5.Controllers
{
    public class JaulaController : Controller
    {
        private IRepository repository;
        byte[] imageDefault;


            public JaulaController()
            {
            imageDefault= ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png");
            using (var scope = AutofacConfig.container.BeginLifetimeScope())
            {
                repository = scope.Resolve<IRepository>();

            }
        }


        // GET: Jaula
        public async Task<ActionResult> Index()
        {
            return View(repository.getAllJails());
        }

        // GET: Jaula/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaula jaula = repository.getJailsByID((int)id);
            foreach (var animal in jaula.Animal)
            {
                if(animal.Imagen == null)
                {
                    animal.Imagen = imageDefault;
                    repository.saveChanges();
                }
            }
            if (jaula == null)
            {
                return HttpNotFound();
            }
            return View(jaula);
        }

        // GET: Jaula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jaula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "JaulaID,PosicionJaula,Capacidad")] Jaula jaula)
        {
            if (ModelState.IsValid)
            {
                repository.saveJail(jaula);
                return RedirectToAction("Index");
            }

            return View(jaula);
        }

        // GET: Jaula/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaula jaula = repository.getJailsByID((int)id);
            if (jaula == null)
            {
                return HttpNotFound();
            }
            return View(jaula);
        }

        // POST: Jaula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "JaulaID,PosicionJaula,Capacidad")] Jaula jaula)
        {
            if (ModelState.IsValid)
            {
                repository.editJail(jaula);
                return RedirectToAction("Index");
            }
            return View(jaula);
        }

        // GET: Jaula/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaula jaula = repository.getJailsByID((int)id);
            if (jaula == null)
            {
                return HttpNotFound();
            }
            return View(jaula);
        }

        // POST: Jaula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            repository.deleteJail(id);
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

        public ActionResult AnimalPartialView(int id)
        {
            //coleccion por jaula
            var animal = repository.getAnimalsJail(id);
            return PartialView("AnimalPartialView", animal.AsEnumerable());
        }
        // GET: Animal/Details/5
        public async Task<ActionResult> AnimalDetails(int? id)
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
    }
}
