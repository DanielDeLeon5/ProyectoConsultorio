using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoConsultorio.Models
{
    public class EspecialidadMedico
    {
        public int Id { get; set; }
        [Required]
        public int idEspecialidad { get; set; }
        [ForeignKey("idEspecialidad")]
        public Especialidad Especialidad { get; set; }
        [Required]
        public int idMedico { get; set; }
        [ForeignKey("idMedico")]
        public Medico Medico { get; set; }
    }
}