using ProyectoConsultorio.Data;
using ProyectoConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProyectoConsultorio.Controllers
{
    [RoutePrefix("api/Paciente")]
    public class PacienteController : ApiController
    {
        private ProyectoConsultorioContext db = new ProyectoConsultorioContext();

        [Route("GetPorDPI/{dpi}")]
        public IQueryable<Paciente> GetPorDPI(string dpi)
        {
            return db.Pacientes.Where(p => p.CUI == dpi);
        }

        [Route("GetOrder/{order}")]
        public IQueryable<Paciente> GetOrder(string order)
        {
            if(order == "A")
            {
                return db.Pacientes.OrderBy(p => p.Apellidos);
            }
            else
            {
                return db.Pacientes.OrderByDescending(p => p.Apellidos);
            }
        }

        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(paciente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = paciente.Id }, paciente);
        }
    }
}
