using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoConsultorio.Data
{
    public class ProyectoConsultorioContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProyectoConsultorioContext() : base("name=ProyectoConsultorioContext")
        {
        }

        public System.Data.Entity.DbSet<ProyectoConsultorio.Models.Paciente> Pacientes { get; set; }

        public System.Data.Entity.DbSet<ProyectoConsultorio.Models.Especialidad> Especialidads { get; set; }

        public System.Data.Entity.DbSet<ProyectoConsultorio.Models.Medico> Medicos { get; set; }

        public System.Data.Entity.DbSet<ProyectoConsultorio.Models.EspecialidadMedico> EspecialidadMedicoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoConsultorio.Models.Consulta> Consultas { get; set; }

        public System.Data.Entity.DbSet<ProyectoConsultorio.Models.Diagnostico> Diagnosticoes { get; set; }
    }
}
