using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoConsultorio.Data;
using ProyectoConsultorio.Models;

namespace ProyectoConsultorio.Controllers
{
    public class EspecialidadMedicoesController : Controller
    {
        private ProyectoConsultorioContext db = new ProyectoConsultorioContext();

        // GET: EspecialidadMedicoes
        public async Task<ActionResult> Index()
        {
            var especialidadMedicoes = db.EspecialidadMedicoes.Include(e => e.Especialidad).Include(e => e.Medico);
            return View(await especialidadMedicoes.ToListAsync());
        }

        // GET: EspecialidadMedicoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadMedico especialidadMedico = await db.EspecialidadMedicoes.FindAsync(id);
            if (especialidadMedico == null)
            {
                return HttpNotFound();
            }
            return View(especialidadMedico);
        }

        // GET: EspecialidadMedicoes/Create
        public ActionResult Create()
        {
            ViewBag.idEspecialidad = new SelectList(db.Especialidads, "Id", "Nombre");
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos");
            return View();
        }

        // POST: EspecialidadMedicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,idEspecialidad,idMedico")] EspecialidadMedico especialidadMedico)
        {
            if (ModelState.IsValid)
            {
                db.EspecialidadMedicoes.Add(especialidadMedico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idEspecialidad = new SelectList(db.Especialidads, "Id", "Nombre", especialidadMedico.idEspecialidad);
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos", especialidadMedico.idMedico);
            return View(especialidadMedico);
        }

        // GET: EspecialidadMedicoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadMedico especialidadMedico = await db.EspecialidadMedicoes.FindAsync(id);
            if (especialidadMedico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEspecialidad = new SelectList(db.Especialidads, "Id", "Nombre", especialidadMedico.idEspecialidad);
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos", especialidadMedico.idMedico);
            return View(especialidadMedico);
        }

        // POST: EspecialidadMedicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,idEspecialidad,idMedico")] EspecialidadMedico especialidadMedico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidadMedico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idEspecialidad = new SelectList(db.Especialidads, "Id", "Nombre", especialidadMedico.idEspecialidad);
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos", especialidadMedico.idMedico);
            return View(especialidadMedico);
        }

        // GET: EspecialidadMedicoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadMedico especialidadMedico = await db.EspecialidadMedicoes.FindAsync(id);
            if (especialidadMedico == null)
            {
                return HttpNotFound();
            }
            return View(especialidadMedico);
        }

        // POST: EspecialidadMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EspecialidadMedico especialidadMedico = await db.EspecialidadMedicoes.FindAsync(id);
            db.EspecialidadMedicoes.Remove(especialidadMedico);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
