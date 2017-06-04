using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Venta
    {
        public int VentaId { get; set; }

        public Cliente Cliente { get; set; }

        public TipoPago TipoPago { get; set; }

        public Contrato Contrato { get; set; }

        public Evaluacion Evaluacion { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public CentroAtencion CentroAtencion { get; set; }
        public int CentroAtencionId { get; set; }

        public Venta()
        {

        }
    }
}
