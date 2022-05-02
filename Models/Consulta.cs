using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoConsultorio.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaCita { get; set; }
        public DateTime FechaSiguiente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string PresionA { get; set; }
        [Required]
        public string Estado { get; set; }
        public string Sintomas { get; set; }
        [Required]
        public int idPaciente { get; set; }
        [ForeignKey("idPaciente")]
        public Paciente Paciente { get; set; }
        public int idMedico { get; set; }
        [ForeignKey("idMedico")]
        public Medico Medico { get; set; }
    }
}