using _2015116292_ENT;
using _2015116292_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class TipodeevaluacionConfiguration : EntityTypeConfiguration<Tipodeevaluacion>
    {
        public TipodeevaluacionConfiguration()
        {
            ToTable("Tipodeevaluacion");
            HasKey(tipo => tipo.Tipodeevaluacion_id);

            HasRequired(tipo => tipo.Evaluacion)
                 .WithMany(tipo => tipo._Tipodeevaluacion);


        }
    }
}
