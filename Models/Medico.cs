using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoConsultorio.Models
{
    public class Medico
    {
        public int Id { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string CUI { get; set; }
        public string Colegiado { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public string CodigoVerificacion { get; set; }
      
        public string Telefono { get; set; }
        public int jefe_idMedico { get; set; }
    }
}