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
    public class DiagnosticoesController : Controller
    {
        private ProyectoConsultorioContext db = new ProyectoConsultorioContext();

        // GET: Diagnosticoes
        public async Task<ActionResult> Index()
        {
            var diagnosticoes = db.Diagnosticoes.Include(d => d.Consulta);
            return View(await diagnosticoes.ToListAsync());
        }

        // GET: Diagnosticoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = await db.Diagnosticoes.FindAsync(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // GET: Diagnosticoes/Create
        public ActionResult Create()
        {
            ViewBag.idConsulta = new SelectList(db.Consultas, "Id", "Peso");
            return View();
        }

        // POST: Diagnosticoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Indicaciones,Observaciones,Imagen,idConsulta")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Diagnosticoes.Add(diagnostico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idConsulta = new SelectList(db.Consultas, "Id", "Peso", diagnostico.idConsulta);
            return View(diagnostico);
        }

        // GET: Diagnosticoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = await db.Diagnosticoes.FindAsync(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsulta = new SelectList(db.Consultas, "Id", "Peso", diagnostico.idConsulta);
            return View(diagnostico);
        }

        // POST: Diagnosticoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Indicaciones,Observaciones,Imagen,idConsulta")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnostico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idConsulta = new SelectList(db.Consultas, "Id", "Peso", diagnostico.idConsulta);
            return View(diagnostico);
        }

        // GET: Diagnosticoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = await db.Diagnosticoes.FindAsync(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // POST: Diagnosticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Diagnostico diagnostico = await db.Diagnosticoes.FindAsync(id);
            db.Diagnosticoes.Remove(diagnostico);
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
