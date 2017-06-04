using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class TipoTrabajador
    {
        public int TipoTrabajadorId { get; set; }

        public ICollection<Trabajador> Trabajador { get; set; }
        public int TrabajadorId { get; set; }

        public TipoTrabajador()
        {
            Trabajador = new Collection<Trabajador>();
        }
    }
}
