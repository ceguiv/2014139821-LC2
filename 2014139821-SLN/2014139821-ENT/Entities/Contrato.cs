using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Contrato
    {
        public int ContratoId { get; set; }

        public Venta Venta { get; set; }
        public int VentaId { get; set; }

        public Contrato()
        {


        }
    }
}
