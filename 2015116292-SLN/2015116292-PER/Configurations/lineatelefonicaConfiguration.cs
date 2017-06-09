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
    public class lineatelefonicaConfiguration : EntityTypeConfiguration<lineatelefonica>
    {
        public lineatelefonicaConfiguration()
        {
            ToTable("lineatelefonica");
            HasKey(li => li.lineatelefonica_id);

            Property(li => li.lineatelefonica_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(li => li.lineatelefonica_numero)
                .IsRequired();

            HasRequired(v => v._tipolinea)
                .WithMany(g => g._lineatelefonica)
                .HasForeignKey(v => v.tipolinea_id);

        }
    }
}
