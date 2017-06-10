using _2014139821_ENT;
using _2014139821_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.Repositories
{
    public class TipoEvaluacionRepository : Repository<TipoEvaluacion>, ITipoEvaluacionRepository
    {
        public TipoEvaluacionRepository(_2014139821_DbContext context):base(context)
        {

        }
    }
}
