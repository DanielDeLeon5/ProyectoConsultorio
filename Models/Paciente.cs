using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoConsultorio.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Sexo { get; set; }
        public string CUI { get; set; }
        public string Telefono { get; set; }
    }
}