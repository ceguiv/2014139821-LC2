using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Venta
    {
        public Contrato Contrato { get; set; }

        public TipoPago TipoPago { get; set; }

        public Cliente Cliente { get; set; }

        public Evaluacion Evaluacion { get; set; }

        public CentroAtencion CentroAtencion { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public Venta()
        {
            Evaluacion = new Evaluacion();
            Contrato = new Contrato();
            TipoPago = new TipoPago();
            LineaTelefonica = new LineaTelefonica();

        }

        public Venta(Cliente cliente, CentroAtencion centroAtencion)
        {
            Cliente = cliente;
            CentroAtencion = centroAtencion;
        }
    }
}
