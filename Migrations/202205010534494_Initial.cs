namespace ProyectoConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FechaCreacion = c.DateTime(nullable: false),
                    FechaCita = c.DateTime(nullable: false),
                    FechaSiguiente = c.DateTime(nullable: false),
                    FechaInicio = c.DateTime(nullable: false),
                    FechaFin = c.DateTime(nullable: false),
                    Peso = c.String(),
                    Altura = c.String(),
                    PresionA = c.String(),
                    Estado = c.String(nullable: false),
                    Sintomas = c.String(),
                    idPaciente = c.Int(nullable: false),
                    idMedico = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.idMedico, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.idPaciente, cascadeDelete: true)
                .Index(t => t.idPaciente)
                .Index(t => t.idMedico);

            CreateTable(
                "dbo.Medicos",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Apellidos = c.String(nullable: false),
                    Nombres = c.String(nullable: false),
                    CUI = c.String(nullable: false),
                    Colegiado = c.String(),
                    Sexo = c.String(nullable: false),
                    Correo = c.String(nullable: false),
                    FechaNacimiento = c.DateTime(nullable: false),
                    CodigoVerificacion = c.String(),
                    Telefono = c.String(),
                    jefe_idMedico = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.jefe_idMedico)
                .Index(t => t.jefe_idMedico);

            CreateTable(
                "dbo.Pacientes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Apellidos = c.String(nullable: false),
                    Nombres = c.String(nullable: false),
                    FechaNacimiento = c.DateTime(nullable: false),
                    Sexo = c.String(nullable: false),
                    CUI = c.String(),
                    Telefono = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Diagnosticoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Indicaciones = c.String(nullable: false),
                    Observaciones = c.String(),
                    Imagen = c.String(),
                    idConsulta = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultas", t => t.idConsulta, cascadeDelete: true)
                .Index(t => t.idConsulta);

            CreateTable(
                "dbo.EspecialidadMedicoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    idEspecialidad = c.Int(nullable: false),
                    idMedico = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especialidads", t => t.idEspecialidad, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.idMedico, cascadeDelete: true)
                .Index(t => t.idEspecialidad)
                .Index(t => t.idMedico);

            CreateTable(
                "dbo.Especialidads",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Descripcion = c.String(),
                    padre_idEspecialidad = c.Int(nullable: true),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {

            DropForeignKey("dbo.EspecialidadMedicoes", "idMedico", "dbo.Especialidads");
            DropForeignKey("dbo.EspecialidadMedicoes", "idEspecialidad", "dbo.Especialidads");
            DropForeignKey("dbo.Especialidads", "padre_idEspecialidad", "dbo.Especialidads");
            DropForeignKey("dbo.Consultas", "idPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "idMedico", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "jefe_idMedico", "dbo.Medicos");
            DropIndex("dbo.Especialidads", new[] { "padre_idEspecialidad" });
            DropIndex("dbo.EspecialidadMedicoes", new[] { "idMedico" });
            DropIndex("dbo.EspecialidadMedicoes", new[] { "idEspecialidad" });
            DropIndex("dbo.Medicos", new[] { "jefe_idMedico" });
            DropIndex("dbo.Consultas", new[] { "idMedico" });
            DropIndex("dbo.Consultas", new[] { "idPaciente" });
            DropTable("dbo.Especialidads");
            DropTable("dbo.EspecialidadMedicoes");
            DropTable("dbo.Diagnosticoes");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Consultas");
        }
    }
}
