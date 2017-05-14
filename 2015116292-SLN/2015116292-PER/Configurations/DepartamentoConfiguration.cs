using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
   public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {

        public DepartamentoConfiguration()
        {
            ToTable("Departamento");
            HasKey(dep => dep.Departamento_id);


        }
    }
}
