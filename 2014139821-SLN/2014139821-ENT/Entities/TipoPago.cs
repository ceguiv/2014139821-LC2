using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class TipoPago
    {
        public int TipoPagoId { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public int VentaId { get; set; }

        public TipoPago()
        {
            Venta = new Collection<Venta>();
        }
    }
}
