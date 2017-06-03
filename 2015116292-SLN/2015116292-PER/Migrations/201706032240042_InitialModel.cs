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
                        admilinea_nombre = c.String(),
                    })
                .PrimaryKey(t => t.admilinea_id);
            
            CreateTable(
                "dbo.lineatelefonica",
                c => new
                    {
                        lineatelefonica_id = c.String(nullable: false, maxLength: 128),
                        lineatelefonica_numero = c.String(),
                        Evaluacion_id = c.String(),
                        admilinea_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.lineatelefonica_id)
                .ForeignKey("dbo.AdmiLinea", t => t.admilinea_id, cascadeDelete: true)
                .ForeignKey("dbo.Evaluacion", t => t.lineatelefonica_id)
                .Index(t => t.lineatelefonica_id)
                .Index(t => t.admilinea_id);
            
            CreateTable(
                "dbo.tipolinea",
                c => new
                    {
                        tipolinea_id = c.String(nullable: false, maxLength: 128),
                        tipolinea_nombre = c.String(),
                        lineatelefonica_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.tipolinea_id)
                .ForeignKey("dbo.lineatelefonica", t => t.lineatelefonica_id, cascadeDelete: true)
                .Index(t => t.lineatelefonica_id);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        Evaluacion_id = c.String(nullable: false, maxLength: 128),
                        Evaluacion_caso = c.String(),
                        Cliente_id = c.String(),
                        Plan_id = c.String(),
                        lineatelefonica_id = c.String(),
                        Centrodeatencion_id = c.String(),
                        Trabajador_id = c.String(),
                        Equipocelular_id = c.String(),
                        Estadodeevaluacion_id = c.String(),
                        Tipodeevaluacion_id = c.String(),
                    })
                .PrimaryKey(t => t.Evaluacion_id);
            
            CreateTable(
                "dbo.Equipocelular",
                c => new
                    {
                        Equipocelular_id = c.String(nullable: false, maxLength: 128),
                        Equipocelular_modelo = c.String(),
                        AdministradorEquipo_id = c.String(nullable: false, maxLength: 128),
                        Evaluacion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Equipocelular_id)
                .ForeignKey("dbo.AdministradorEquipo", t => t.AdministradorEquipo_id, cascadeDelete: true)
                .ForeignKey("dbo.Evaluacion", t => t.Evaluacion_id, cascadeDelete: true)
                .Index(t => t.AdministradorEquipo_id)
                .Index(t => t.Evaluacion_id);
            
            CreateTable(
                "dbo.AdministradorEquipo",
                c => new
                    {
                        AdministradorEquipo_id = c.String(nullable: false, maxLength: 128),
                        AdministradorEquipo_modelo = c.String(),
                    })
                .PrimaryKey(t => t.AdministradorEquipo_id);
            
            CreateTable(
                "dbo.Estadodeevaluacion",
                c => new
                    {
                        Estadodeevaluacion_id = c.String(nullable: false, maxLength: 128),
                        Estadodeevaluacion_estado = c.String(),
                        Evaluacion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Estadodeevaluacion_id)
                .ForeignKey("dbo.Evaluacion", t => t.Evaluacion_id, cascadeDelete: true)
                .Index(t => t.Evaluacion_id);
            
            CreateTable(
                "dbo.Tipodeevaluacion",
                c => new
                    {
                        Tipodeevaluacion_id = c.String(nullable: false, maxLength: 128),
                        Tipodeevaluacion_tipo = c.String(),
                        Evaluacion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Tipodeevaluacion_id)
                .ForeignKey("dbo.Evaluacion", t => t.Evaluacion_id, cascadeDelete: true)
                .Index(t => t.Evaluacion_id);
            
            CreateTable(
                "dbo.Centrodeatencion",
                c => new
                    {
                        Centrodeatencion_id = c.String(nullable: false, maxLength: 128),
                        Centrodeatencion_nombre = c.String(),
                        Evaluacion_id = c.String(),
                    })
                .PrimaryKey(t => t.Centrodeatencion_id)
                .ForeignKey("dbo.Evaluacion", t => t.Centrodeatencion_id)
                .Index(t => t.Centrodeatencion_id);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Direccion_id = c.String(nullable: false, maxLength: 128),
                        Direccion_lugar = c.String(),
                        Centrodeatencion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Direccion_id)
                .ForeignKey("dbo.Centrodeatencion", t => t.Centrodeatencion_id, cascadeDelete: true)
                .Index(t => t.Centrodeatencion_id);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        Ubigeo_id = c.String(nullable: false, maxLength: 128),
                        Ubigeo_numero = c.String(),
                        Direccion_id = c.String(nullable: false, maxLength: 128),
                        Departamento_Departamento_id = c.String(maxLength: 128),
                        Distrito_Distrito_id = c.String(maxLength: 128),
                        Provincia_Provincia_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Ubigeo_id)
                .ForeignKey("dbo.Departamento", t => t.Departamento_Departamento_id)
                .ForeignKey("dbo.Direccion", t => t.Direccion_id, cascadeDelete: true)
                .ForeignKey("dbo.Distrito", t => t.Distrito_Distrito_id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_Provincia_id)
                .Index(t => t.Direccion_id)
                .Index(t => t.Departamento_Departamento_id)
                .Index(t => t.Distrito_Distrito_id)
                .Index(t => t.Provincia_Provincia_id);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Departamento_id = c.String(nullable: false, maxLength: 128),
                        Departamento_nombre = c.String(),
                    })
                .PrimaryKey(t => t.Departamento_id);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Provincia_id = c.String(nullable: false, maxLength: 128),
                        Provincia_nombre = c.String(),
                        Departamento_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Provincia_id)
                .ForeignKey("dbo.Departamento", t => t.Departamento_id, cascadeDelete: true)
                .Index(t => t.Departamento_id);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        Distrito_id = c.String(nullable: false, maxLength: 128),
                        Distrito_nombre = c.String(),
                        Provincia_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Distrito_id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_id, cascadeDelete: true)
                .Index(t => t.Provincia_id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Cliente_id = c.String(nullable: false, maxLength: 128),
                        Cliente_nombre = c.String(),
                        Evaluacion_id = c.String(),
                    })
                .PrimaryKey(t => t.Cliente_id)
                .ForeignKey("dbo.Evaluacion", t => t.Cliente_id)
                .Index(t => t.Cliente_id);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        Plan_id = c.String(nullable: false, maxLength: 128),
                        Plan_descripcion = c.String(),
                        Evaluacion_id = c.String(),
                    })
                .PrimaryKey(t => t.Plan_id)
                .ForeignKey("dbo.Evaluacion", t => t.Plan_id)
                .Index(t => t.Plan_id);
            
            CreateTable(
                "dbo.TipoPlan",
                c => new
                    {
                        TipoPlan_id = c.String(nullable: false, maxLength: 128),
                        TipoPlan_caracteristica = c.String(),
                        Plan_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TipoPlan_id)
                .ForeignKey("dbo.Plan", t => t.Plan_id, cascadeDelete: true)
                .Index(t => t.Plan_id);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        Trabajador_id = c.String(nullable: false, maxLength: 128),
                        Trabajador_nombre = c.String(),
                        Trabajador_tipotrab = c.String(),
                        Evaluacion_id = c.String(),
                    })
                .PrimaryKey(t => t.Trabajador_id)
                .ForeignKey("dbo.Evaluacion", t => t.Trabajador_id)
                .Index(t => t.Trabajador_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trabajador", "Trabajador_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Plan", "Plan_id", "dbo.Evaluacion");
            DropForeignKey("dbo.TipoPlan", "Plan_id", "dbo.Plan");
            DropForeignKey("dbo.lineatelefonica", "lineatelefonica_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Cliente", "Cliente_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Centrodeatencion", "Centrodeatencion_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Direccion", "Centrodeatencion_id", "dbo.Centrodeatencion");
            DropForeignKey("dbo.Ubigeo", "Provincia_Provincia_id", "dbo.Provincia");
            DropForeignKey("dbo.Ubigeo", "Distrito_Distrito_id", "dbo.Distrito");
            DropForeignKey("dbo.Ubigeo", "Direccion_id", "dbo.Direccion");
            DropForeignKey("dbo.Ubigeo", "Departamento_Departamento_id", "dbo.Departamento");
            DropForeignKey("dbo.Provincia", "Departamento_id", "dbo.Departamento");
            DropForeignKey("dbo.Distrito", "Provincia_id", "dbo.Provincia");
            DropForeignKey("dbo.Tipodeevaluacion", "Evaluacion_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Estadodeevaluacion", "Evaluacion_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Equipocelular", "Evaluacion_id", "dbo.Evaluacion");
            DropForeignKey("dbo.Equipocelular", "AdministradorEquipo_id", "dbo.AdministradorEquipo");
            DropForeignKey("dbo.lineatelefonica", "admilinea_id", "dbo.AdmiLinea");
            DropForeignKey("dbo.tipolinea", "lineatelefonica_id", "dbo.lineatelefonica");
            DropIndex("dbo.Trabajador", new[] { "Trabajador_id" });
            DropIndex("dbo.TipoPlan", new[] { "Plan_id" });
            DropIndex("dbo.Plan", new[] { "Plan_id" });
            DropIndex("dbo.Cliente", new[] { "Cliente_id" });
            DropIndex("dbo.Distrito", new[] { "Provincia_id" });
            DropIndex("dbo.Provincia", new[] { "Departamento_id" });
            DropIndex("dbo.Ubigeo", new[] { "Provincia_Provincia_id" });
            DropIndex("dbo.Ubigeo", new[] { "Distrito_Distrito_id" });
            DropIndex("dbo.Ubigeo", new[] { "Departamento_Departamento_id" });
            DropIndex("dbo.Ubigeo", new[] { "Direccion_id" });
            DropIndex("dbo.Direccion", new[] { "Centrodeatencion_id" });
            DropIndex("dbo.Centrodeatencion", new[] { "Centrodeatencion_id" });
            DropIndex("dbo.Tipodeevaluacion", new[] { "Evaluacion_id" });
            DropIndex("dbo.Estadodeevaluacion", new[] { "Evaluacion_id" });
            DropIndex("dbo.Equipocelular", new[] { "Evaluacion_id" });
            DropIndex("dbo.Equipocelular", new[] { "AdministradorEquipo_id" });
            DropIndex("dbo.tipolinea", new[] { "lineatelefonica_id" });
            DropIndex("dbo.lineatelefonica", new[] { "admilinea_id" });
            DropIndex("dbo.lineatelefonica", new[] { "lineatelefonica_id" });
            DropTable("dbo.Trabajador");
            DropTable("dbo.TipoPlan");
            DropTable("dbo.Plan");
            DropTable("dbo.Cliente");
            DropTable("dbo.Distrito");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.Direccion");
            DropTable("dbo.Centrodeatencion");
            DropTable("dbo.Tipodeevaluacion");
            DropTable("dbo.Estadodeevaluacion");
            DropTable("dbo.AdministradorEquipo");
            DropTable("dbo.Equipocelular");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.tipolinea");
            DropTable("dbo.lineatelefonica");
            DropTable("dbo.AdmiLinea");
        }
    }
}
