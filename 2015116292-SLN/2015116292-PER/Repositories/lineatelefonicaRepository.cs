using _2015116292_ENT.Entities;
using _2015116292_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Repositories
{
    public class lineatelefonicaRepository : Repository<lineatelefonica>, IlineatelefonicaRepository
    {
        private readonly _2015116292_DbContext _Context;

        public lineatelefonicaRepository(_2015116292_DbContext context)
        {
            _Context = context;
        }

        private lineatelefonicaRepository()
        {
                
        }
    }

}
