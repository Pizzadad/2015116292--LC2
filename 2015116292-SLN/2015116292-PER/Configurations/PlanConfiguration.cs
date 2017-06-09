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
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plan");
            HasKey(p => p.Plan_id);

            Property(p => p.Plan_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Plan_descripcion)
                .IsRequired();

            HasRequired(v => v._TipoPlan)
                .WithMany(g => g._Plan)
                .HasForeignKey(v => v.TipoPlan_id);

        }
    }
}
