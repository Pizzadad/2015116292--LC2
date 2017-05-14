using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2015116292_ENT;
using _2015116292_PER.Configurations;

namespace _2015116292_PER
{
    class _2015116292_DbContext : DbContext
    {
        public DbSet<tipolinea> tipolinea { get; set; }
        public DbSet<TipoPlan> TipoPlan { get; set; }
        public DbSet<AdmiLinea> AdmiLinea { get; set; }
        public DbSet<AdministradorEquipo> AdministradorEquipo { get; set; }
        public DbSet<Centrodeatencion> Centrodeatencion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Equipocelular> Equipocelular { get; set; }
        public DbSet<Estadodeevaluacion> Estadodeevaluacion { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<lineatelefonica> lineatelefonica { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Tipodeevaluacion> Tipodeevaluacion { get; set; }
        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }
        
      		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new EvaluacionConfiguration());

			base.OnModelCreating(modelBuilder);
		}
         
    }
}
