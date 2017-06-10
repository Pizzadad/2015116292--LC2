namespace _2015116292_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmiLinea",
                c => new
                    {
                        admilinea_id = c.String(nullable: false, maxLength: 128),
                        admilinea_nombre = c.String(nullable: false),
                        lineatelefonica_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.admilinea_id)
                .ForeignKey("dbo.lineatelefonica", t => t.lineatelefonica_id, cascadeDelete: true)
                .Index(t => t.lineatelefonica_id);
            
            CreateTable(
                "dbo.lineatelefonica",
                c => new
                    {
                        lineatelefonica_id = c.String(nullable: false, maxLength: 128),
                        lineatelefonica_numero = c.String(nullable: false),
                        tipolinea_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.lineatelefonica_id)
                .ForeignKey("dbo.tipolinea", t => t.tipolinea_id, cascadeDelete: true)
                .Index(t => t.tipolinea_id);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        Evaluacion_id = c.String(nullable: false, maxLength: 128),
                        Evaluacion_caso = c.String(nullable: false),
                        Cliente_id = c.String(nullable: false, maxLength: 128),
                        Plan_id = c.String(nullable: false, maxLength: 128),
                        lineatelefonica_id = c.String(nullable: false, maxLength: 128),
                        Centrodeatencion_id = c.String(nullable: false, maxLength: 128),
                        Trabajador_id = c.String(nullable: false, maxLength: 128),
                        Equipocelular_id = c.String(nullable: false, maxLength: 128),
                        Estadodeevaluacion_id = c.String(nullable: false, maxLength: 128),
                        Tipodeevaluacion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Evaluacion_id)
                .ForeignKey("dbo.Centrodeatencion", t => t.Centrodeatencion_id, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_id, cascadeDelete: true)
                .ForeignKey("dbo.Equipocelular", t => t.Equipocelular_id, cascadeDelete: true)
                .ForeignKey("dbo.Estadodeevaluacion", t => t.Estadodeevaluacion_id, cascadeDelete: true)
                .ForeignKey("dbo.lineatelefonica", t => t.lineatelefonica_id, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.Plan_id, cascadeDelete: true)
                .ForeignKey("dbo.Tipodeevaluacion", t => t.Tipodeevaluacion_id, cascadeDelete: true)
                .ForeignKey("dbo.Trabajador", t => t.Trabajador_id, cascadeDelete: true)
                .Index(t => t.Cliente_id)
                .Index(t => t.Plan_id)
                .Index(t => t.lineatelefonica_id)
                .Index(t => t.Centrodeatencion_id)
                .Index(t => t.Trabajador_id)
                .Index(t => t.Equipocelular_id)
                .Index(t => t.Estadodeevaluacion_id)
                .Index(t => t.Tipodeevaluacion_id);
            
            CreateTable(
                "dbo.Centrodeatencion",
                c => new
                    {
                        Centrodeatencion_id = c.String(nullable: false, maxLength: 128),
                        Centrodeatencion_nombre = c.String(nullable: false),
                        Direccion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Centrodeatencion_id)
                .ForeignKey("dbo.Direccion", t => t.Direccion_id, cascadeDelete: true)
                .Index(t => t.Direccion_id);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Direccion_id = c.String(nullable: false, maxLength: 128),
                        Direccion_lugar = c.String(nullable: false),
                        Ubigeo_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Direccion_id)
                .ForeignKey("dbo.Ubigeo", t => t.Ubigeo_id, cascadeDelete: true)
                .Index(t => t.Ubigeo_id);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        Ubigeo_id = c.String(nullable: false, maxLength: 128),
                        Ubigeo_numero = c.String(nullable: false),
                        Departamento_id = c.String(nullable: false, maxLength: 128),
                        Provincia_id = c.String(maxLength: 128),
                        Distrito_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Ubigeo_id)
                .ForeignKey("dbo.Departamento", t => t.Departamento_id, cascadeDelete: true)
                .ForeignKey("dbo.Distrito", t => t.Distrito_id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_id)
                .Index(t => t.Departamento_id)
                .Index(t => t.Provincia_id)
                .Index(t => t.Distrito_id);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Departamento_id = c.String(nullable: false, maxLength: 128),
                        Departamento_nombre = c.String(nullable: false),
                        Provincia_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Departamento_id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_id, cascadeDelete: true)
                .Index(t => t.Provincia_id);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Provincia_id = c.String(nullable: false, maxLength: 128),
                        Provincia_nombre = c.String(nullable: false),
                        Distrito_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Provincia_id)
                .ForeignKey("dbo.Distrito", t => t.Distrito_id, cascadeDelete: true)
                .Index(t => t.Distrito_id);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        Distrito_id = c.String(nullable: false, maxLength: 128),
                        Distrito_nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Distrito_id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Cliente_id = c.String(nullable: false, maxLength: 128),
                        Cliente_nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Cliente_id);
            
            CreateTable(
                "dbo.Equipocelular",
                c => new
                    {
                        Equipocelular_id = c.String(nullable: false, maxLength: 128),
                        Equipocelular_modelo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Equipocelular_id);
            
            CreateTable(
                "dbo.AdministradorEquipo",
                c => new
                    {
                        AdministradorEquipo_id = c.String(nullable: false, maxLength: 128),
                        AdministradorEquipo_modelo = c.String(nullable: false),
                        Equipocelular_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AdministradorEquipo_id)
                .ForeignKey("dbo.Equipocelular", t => t.Equipocelular_id, cascadeDelete: true)
                .Index(t => t.Equipocelular_id);
            
            CreateTable(
                "dbo.Estadodeevaluacion",
                c => new
                    {
                        Estadodeevaluacion_id = c.String(nullable: false, maxLength: 128),
                        Estadodeevaluacion_estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Estadodeevaluacion_id);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        Plan_id = c.String(nullable: false, maxLength: 128),
                        Plan_descripcion = c.String(nullable: false),
                        TipoPlan_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Plan_id)
                .ForeignKey("dbo.TipoPlan", t => t.TipoPlan_id, cascadeDelete: true)
                .Index(t => t.TipoPlan_id);
            
            CreateTable(
                "dbo.TipoPlan",
                c => new
                    {
                        TipoPlan_id = c.String(nullable: false, maxLength: 128),
                        TipoPlan_caracteristica = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPlan_id);
            
            CreateTable(
                "dbo.Tipodeevaluacion",
                c => new
                    {
                        Tipodeevaluacion_id = c.String(nullable: false, maxLength: 128),
                        Tipodeevaluacion_tipo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Tipodeevaluacion_id);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        Trabajador_id = c.String(nullable: false, maxLength: 128),
                        Trabajador_nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Trabajador_id);
            
            CreateTable(
                "dbo.tipolinea",
                c => new
                    {
                        tipolinea_id = c.String(nullable: false, maxLength: 128),
                        tipolinea_nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.tipolinea_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdmiLinea", "lineatelefonica_id", "dbo.lineatelefonica");
            DropForeignKey("dbo.lineatelefonica", "tipolinea_id", "dbo.tipolinea");
            DropForeignKey("dbo.Evaluacion", "Trabajador_id", "dbo.Trabajador");
            DropForeignKey("dbo.Evaluacion", "Tipodeevaluacion_id", "dbo.Tipodeevaluacion");
            DropForeignKey("dbo.Evaluacion", "Plan_id", "dbo.Plan");
            DropForeignKey("dbo.Plan", "TipoPlan_id", "dbo.TipoPlan");
            DropForeignKey("dbo.Evaluacion", "lineatelefonica_id", "dbo.lineatelefonica");
            DropForeignKey("dbo.Evaluacion", "Estadodeevaluacion_id", "dbo.Estadodeevaluacion");
            DropForeignKey("dbo.Evaluacion", "Equipocelular_id", "dbo.Equipocelular");
            DropForeignKey("dbo.AdministradorEquipo", "Equipocelular_id", "dbo.Equipocelular");
            DropForeignKey("dbo.Evaluacion", "Cliente_id", "dbo.Cliente");
            DropForeignKey("dbo.Evaluacion", "Centrodeatencion_id", "dbo.Centrodeatencion");
            DropForeignKey("dbo.Centrodeatencion", "Direccion_id", "dbo.Direccion");
            DropForeignKey("dbo.Direccion", "Ubigeo_id", "dbo.Ubigeo");
            DropForeignKey("dbo.Ubigeo", "Provincia_id", "dbo.Provincia");
            DropForeignKey("dbo.Ubigeo", "Distrito_id", "dbo.Distrito");
            DropForeignKey("dbo.Ubigeo", "Departamento_id", "dbo.Departamento");
            DropForeignKey("dbo.Departamento", "Provincia_id", "dbo.Provincia");
            DropForeignKey("dbo.Provincia", "Distrito_id", "dbo.Distrito");
            DropIndex("dbo.Plan", new[] { "TipoPlan_id" });
            DropIndex("dbo.AdministradorEquipo", new[] { "Equipocelular_id" });
            DropIndex("dbo.Provincia", new[] { "Distrito_id" });
            DropIndex("dbo.Departamento", new[] { "Provincia_id" });
            DropIndex("dbo.Ubigeo", new[] { "Distrito_id" });
            DropIndex("dbo.Ubigeo", new[] { "Provincia_id" });
            DropIndex("dbo.Ubigeo", new[] { "Departamento_id" });
            DropIndex("dbo.Direccion", new[] { "Ubigeo_id" });
            DropIndex("dbo.Centrodeatencion", new[] { "Direccion_id" });
            DropIndex("dbo.Evaluacion", new[] { "Tipodeevaluacion_id" });
            DropIndex("dbo.Evaluacion", new[] { "Estadodeevaluacion_id" });
            DropIndex("dbo.Evaluacion", new[] { "Equipocelular_id" });
            DropIndex("dbo.Evaluacion", new[] { "Trabajador_id" });
            DropIndex("dbo.Evaluacion", new[] { "Centrodeatencion_id" });
            DropIndex("dbo.Evaluacion", new[] { "lineatelefonica_id" });
            DropIndex("dbo.Evaluacion", new[] { "Plan_id" });
            DropIndex("dbo.Evaluacion", new[] { "Cliente_id" });
            DropIndex("dbo.lineatelefonica", new[] { "tipolinea_id" });
            DropIndex("dbo.AdmiLinea", new[] { "lineatelefonica_id" });
            DropTable("dbo.tipolinea");
            DropTable("dbo.Trabajador");
            DropTable("dbo.Tipodeevaluacion");
            DropTable("dbo.TipoPlan");
            DropTable("dbo.Plan");
            DropTable("dbo.Estadodeevaluacion");
            DropTable("dbo.AdministradorEquipo");
            DropTable("dbo.Equipocelular");
            DropTable("dbo.Cliente");
            DropTable("dbo.Distrito");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.Direccion");
            DropTable("dbo.Centrodeatencion");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.lineatelefonica");
            DropTable("dbo.AdmiLinea");
        }
    }
}
