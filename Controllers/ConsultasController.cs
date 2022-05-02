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
    public class ConsultasController : Controller
    {
        private ProyectoConsultorioContext db = new ProyectoConsultorioContext();

        // GET: Consultas
        public async Task<ActionResult> Index()
        {
            var consultas = db.Consultas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(await consultas.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos");
            ViewBag.idPaciente = new SelectList(db.Pacientes, "Id", "Apellidos");
            return View();
        }

        // POST: Consultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FechaCreacion,FechaCita,FechaSiguiente,FechaInicio,FechaFin,Peso,Altura,PresionA,Estado,Sintomas,idPaciente,idMedico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos", consulta.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "Id", "Apellidos", consulta.idPaciente);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos", consulta.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "Id", "Apellidos", consulta.idPaciente);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FechaCreacion,FechaCita,FechaSiguiente,FechaInicio,FechaFin,Peso,Altura,PresionA,Estado,Sintomas,idPaciente,idMedico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idMedico = new SelectList(db.Medicos, "Id", "Apellidos", consulta.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "Id", "Apellidos", consulta.idPaciente);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consulta consulta = await db.Consultas.FindAsync(id);
            db.Consultas.Remove(consulta);
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
