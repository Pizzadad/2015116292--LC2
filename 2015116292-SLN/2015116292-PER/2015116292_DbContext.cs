using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _2015116292_PER.Configurations;
using _2015116292_ENT.Entities;

namespace _2015116292_PER
{
   public class _2015116292_DbContext : DbContext
    {
        public DbSet<tipolinea> tipolinea1 { get; set; }
        public DbSet<TipoPlan> TipoPlan1 { get; set; }
        public DbSet<AdmiLinea> AdmiLinea1 { get; set; }
        public DbSet<AdministradorEquipo> AdministradorEquipo1 { get; set; }
        public DbSet<Centrodeatencion> Centrodeatencion1 { get; set; }
        public DbSet<Cliente> Cliente1 { get; set; }
        public DbSet<Departamento> Departamento1 { get; set; }
        public DbSet<Direccion> Direccion1 { get; set; }
        public DbSet<Distrito> Distrito1 { get; set; }
        public DbSet<Equipocelular> Equipocelular1 { get; set; }
        public DbSet<Estadodeevaluacion> Estadodeevaluacion1 { get; set; }
        public DbSet<Evaluacion> Evaluacion1 { get; set; }
        public DbSet<lineatelefonica> lineatelefonica1 { get; set; }
        public DbSet<Plan> Plan1 { get; set; }
        public DbSet<Provincia> Provincia1 { get; set; }
        public DbSet<Tipodeevaluacion> Tipodeevaluacion1 { get; set; }
        public DbSet<Trabajador> Trabajador1 { get; set; }
        public DbSet<Ubigeo> Ubigeo1 { get; set; }

        public _2015116292_DbContext() : base("LC2_2015116292")
        {

        }

      		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new EvaluacionConfiguration());
            modelBuilder.Configurations.Add(new AdmiLineaConfiguration());
            modelBuilder.Configurations.Add(new AdministradorEquipoConfiguration());
            modelBuilder.Configurations.Add(new CentrodeatencionConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new EquipocelularConfiguration());
            modelBuilder.Configurations.Add(new EstadodeevaluacionConfiguration());
            modelBuilder.Configurations.Add(new lineatelefonicaConfiguration());
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new TipodeevaluacionConfiguration());
            modelBuilder.Configurations.Add(new TipolineaConfiguration());
            modelBuilder.Configurations.Add(new TrabajadorConfiguration());
            modelBuilder.Configurations.Add(new UbigeoConfiguration());
            modelBuilder.Configurations.Add(new TipoPlanConfiguration());

            base.OnModelCreating(modelBuilder);
		}
         
    }
}
