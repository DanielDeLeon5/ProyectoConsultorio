using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoConsultorio.Models
{
    public class Diagnostico
    {
        public int Id { get; set; }
        [Required]
        public string Indicaciones { get; set; }
        public string Observaciones { get; set; }
        public string Imagen { get; set; }

        public int idConsulta { get; set; }
        [ForeignKey("idConsulta")]
        public Consulta Consulta { get; set; }
    }
}