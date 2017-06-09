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
    public class AdmiLineaConfiguration : EntityTypeConfiguration<AdmiLinea>
    {
        public AdmiLineaConfiguration()
        {
            ToTable("AdmiLinea");
            HasKey(ad => ad.admilinea_id);

            Property(ad => ad.admilinea_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(ad => ad.admilinea_nombre)
            .IsRequired();

            HasRequired(v => v._lineatelefonica)
                .WithMany(g => g._AdmiLinea)
                .HasForeignKey(v => v.lineatelefonica_id);
        }
    }
}
