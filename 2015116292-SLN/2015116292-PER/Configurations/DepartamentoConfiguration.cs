using _2015116292_ENT;
using _2015116292_ENT.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
   public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {

        public DepartamentoConfiguration()
        {
            ToTable("Departamento");
            HasKey(dep => dep.Departamento_id);

            Property(dep => dep.Departamento_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(dep => dep.Departamento_nombre)
            .IsRequired();

            HasRequired(v => v._Provincia)
                .WithMany(g => g._Departamento)
                .HasForeignKey(v => v.Provincia_id);
        }
    }
}
