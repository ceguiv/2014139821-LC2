using _2014139821_ENT;
using _2014139821_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly _2014139821_DbContext _context;

        public ClienteRepository(_2014139821_DbContext context)
        {
            _context = context;
        }

        private ClienteRepository()
        {

        }
    }
}
