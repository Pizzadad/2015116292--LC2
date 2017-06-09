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
    public class EstadodeevaluacionConfiguration : EntityTypeConfiguration<Estadodeevaluacion>
    {
        public EstadodeevaluacionConfiguration()
        {
            ToTable("Estadodeevaluacion");
            HasKey(est => est.Estadodeevaluacion_id);

            Property(est => est.Estadodeevaluacion_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(est => est.Estadodeevaluacion_estado)
                .IsRequired();
        }
    }
}
