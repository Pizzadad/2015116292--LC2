using _2015116292_ENT.Entities;
using _2015116292_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Repositories
{
    public class TipoPlanRepository : Repository<TipoPlan>, ITipoPlanRepository
    {
        private readonly _2015116292_DbContext _Context;

        public TipoPlanRepository(_2015116292_DbContext context)
        {
            _Context = context;
        }
        private TipoPlanRepository()
        {

        }
    }

}
