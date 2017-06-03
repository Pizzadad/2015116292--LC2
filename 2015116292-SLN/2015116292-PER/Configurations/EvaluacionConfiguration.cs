using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            ToTable("Evaluacion");
            HasKey(eva => eva.Evaluacion_id);

            HasRequired(eva => eva.Cliente)
              .WithRequiredPrincipal(eva => eva.Evaluacion);

            HasRequired(eva => eva.lineatelefonica)
              .WithRequiredPrincipal(eva => eva.Evaluacion);

            HasRequired(eva => eva.Plan)
              .WithRequiredPrincipal(eva => eva.Evaluacion);

            HasRequired(eva => eva.Trabajador)
              .WithRequiredPrincipal(eva => eva.Evaluacion);

            HasRequired(eva => eva.Centrodeatencion)
             .WithRequiredPrincipal(eva => eva.Evaluacion);


        }
    }
}
