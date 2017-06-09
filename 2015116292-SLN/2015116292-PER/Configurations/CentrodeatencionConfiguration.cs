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
  public  class CentrodeatencionConfiguration :   EntityTypeConfiguration<Centrodeatencion>
    {
        public CentrodeatencionConfiguration()
        {
            ToTable("Centrodeatencion");
            HasKey(cen => cen.Centrodeatencion_id);

            Property(cen => cen.Centrodeatencion_id)
                            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(cen => cen.Centrodeatencion_nombre)
         .IsRequired();


            HasRequired(v => v._Direccion)
                .WithMany(g => g._Centrodeatencion)
                .HasForeignKey(v => v.Direccion_id);
        }
    }
}
