namespace ProyectoConsultorio.Migrations
{
    using ProyectoConsultorio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoConsultorio.Data.ProyectoConsultorioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProyectoConsultorio.Data.ProyectoConsultorioContext context)
        {

            context.Pacientes.AddOrUpdate(new Paciente[]
            {
                new Paciente() { Id = 1, Apellidos = "Perez Lopez", Nombres="Mario Alberto", CUI = "335404169095",
                    FechaNacimiento=new DateTime(2000, 05, 03), Sexo="M", Telefono="47522265"},
                new Paciente() { Id = 2, Apellidos = "Guerra Maldonado", Nombres="Alejandra Maite", CUI = "234484261015",
                    FechaNacimiento=new DateTime(1992, 10, 05), Sexo="F", Telefono="54874691"},
                new Paciente() { Id = 3, Apellidos = "Martinez Aguilar", Nombres="Celeste Leticia", CUI = "186454379305",
                    FechaNacimiento=new DateTime(1990, 03, 11), Sexo="F", Telefono="45698745"}
            });
            context.Especialidads.AddOrUpdate(new Especialidad[]
            {
                new Especialidad() { Id = 1, Nombre = "Pediatria", Descripcion="Atencion a niños"},
                new Especialidad() { Id = 2, Nombre = "Nutricion Pediatrica", Descripcion = "Nutricion enfocada a niños"},
                new Especialidad() { Id = 3, Nombre = "Cardiologia", Descripcion="Enfermedades del corazon"}
            });
        }
    }
}
