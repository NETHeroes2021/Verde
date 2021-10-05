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
using EjercicioFinalMVC5.Services;
using EjercicioFinalMVC5.Services.ID;
using Autofac;

namespace EjercicioFinalMVC5.Controllers
{
    public class EspecieController : Controller
    {
        private IRepository repository;


        public EspecieController()
        {
            using (var scope = AutofacConfig.container.BeginLifetimeScope())
            {
                repository = scope.Resolve<IRepository>();

            }
        }
        // GET: Especie
        public async Task<ActionResult> Index()
        {
            return View(repository.getAllEspecies());
        }

        //GET: Especie/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = repository.getEspecieById(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EspecieID,Descripcion")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                repository.saveEspecie(especie);
                return RedirectToAction("Index");
            }

            return View(especie);
        }

        // GET: Especie/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie =repository.getEspecieById(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especie/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EspecieID,Descripcion")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                repository.editEspecie(especie);
                return RedirectToAction("Index");
            }
            return View(especie);
        }

        // GET: Especie/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = repository.getEspecieById(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            repository.deleteEspecie(id);
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

        public ActionResult EspeciePartialView(int id)
        {
            //coleccion por jaula
            var jaula = repository.getJaulasByAnimal(id);
            return View("EspeciePartialView", jaula.AsEnumerable());
        }
    }
}
