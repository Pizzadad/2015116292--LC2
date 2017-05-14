using _2015116292_ENT;
using System;
using System.Collections.Generic;
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

            HasRequired(est => est.Evaluacion)
                .WithMany(est => est._Estadodeevaluacion);
        }
    }
}
