using _2015116292_ENT.Entities;
using _2015116292_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Repositories
{
    public class UbigeoRepository : Repository<Ubigeo>, IUbigeoRepository
    {
        private readonly _2015116292_DbContext _Context;

        public UbigeoRepository(_2015116292_DbContext context)
        {
            _Context = context;
        }

        private UbigeoRepository()
        {

        }
    }
}
