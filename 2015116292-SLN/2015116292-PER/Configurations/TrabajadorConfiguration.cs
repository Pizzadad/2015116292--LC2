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
    public class TrabajadorConfiguration : EntityTypeConfiguration<Trabajador>
    {
        public TrabajadorConfiguration()
        {
            ToTable("Trabajador");
            HasKey(tra => tra.Trabajador_id);
            Property(tra => tra.Trabajador_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(tra => tra.Trabajador_nombre)
                .IsRequired();
        }
    }
}
