using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionId { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public int VentaId { get; set; }

        public Cliente()
        {
            Evaluacion = new Collection<Evaluacion>();
            Venta = new Collection<Venta>();
        }
    }
}
