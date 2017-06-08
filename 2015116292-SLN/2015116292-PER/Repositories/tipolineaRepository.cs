using _2015116292_ENT.Entities;
using _2015116292_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Repositories
{
    public class tipolineaRepository : Repository<tipolinea>, ItipolineaRepository
    {
        

        public tipolineaRepository(_2015116292_DbContext context) : base(context)
        {
            
        }

        
    }

}
