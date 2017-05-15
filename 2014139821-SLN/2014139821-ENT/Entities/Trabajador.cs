using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Trabajador
    {
        public TipoTrabajador TipoTrabajador { get; set; }

        public Trabajador()
        {
            TipoTrabajador = new TipoTrabajador();
        }
    }
}
