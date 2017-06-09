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
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            ToTable("Evaluacion");
            HasKey(eva => eva.Evaluacion_id);

            Property(eva => eva.Evaluacion_id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(eva => eva.Evaluacion_caso)
                .IsRequired();

             HasRequired(v => v._Cliente)
                .WithMany(g => g._Evaluacion)
                .HasForeignKey(v => v.Cliente_id);

            HasRequired(v => v._Centrodeatencion)
                .WithMany(g => g._Evaluacion)
                .HasForeignKey(v => v.Centrodeatencion_id);

            HasRequired(v => v._Equipocelular)
                .WithMany(g => g._Evaluacion)
                .HasForeignKey(v => v.Equipocelular_id);

            HasRequired(v => v._Estadodeevaluacion)
                .WithMany(g => g._Evaluacion)
                .HasForeignKey(v => v.Estadodeevaluacion_id);

            HasRequired(v => v._lineatelefonica)
                .WithMany(g => g._Evaluacion)
                .HasForeignKey(v => v.lineatelefonica_id);

            HasRequired(v => v._Plan)
                .WithMany(g => g._Evaluacion)
                .HasForeignKey(v => v.Plan_id);

            HasRequired(v => v._Tipodeevaluacion)
               .WithMany(g => g._Evaluacion)
               .HasForeignKey(v => v.Tipodeevaluacion_id);

            HasRequired(v => v._Trabajador)
               .WithMany(g => g._Evaluacion)
               .HasForeignKey(v => v.Trabajador_id);

        }
    }
}
