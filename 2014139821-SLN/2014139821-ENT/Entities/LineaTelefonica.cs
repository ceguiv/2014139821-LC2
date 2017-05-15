using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class LineaTelefonica
    {
        public TipoLinea TipoLinea { get; set; }

        public LineaTelefonica()
        {
            TipoLinea = new TipoLinea();
        }
    }
}
