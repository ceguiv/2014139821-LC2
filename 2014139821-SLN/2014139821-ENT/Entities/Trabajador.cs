using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Trabajador
    {
        public int TrabajadorId { get; set; }

        public TipoTrabajador TipoTrabajador { get; set; }


        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }
    }
}
