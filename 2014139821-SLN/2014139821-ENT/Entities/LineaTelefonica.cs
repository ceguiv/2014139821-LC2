using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class LineaTelefonica
    {
        public int LineaTelefonicaId { get; set; }

        public TipoLinea TipoLinea { get; set; }

        public AdministradorLinea AdministradorLinea { get; set; }
        public int AdministradorLineaId { get; set; }

        public Venta Venta { get; set; }
        public int VentaId { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionId { get; set; }



        public LineaTelefonica()
        {
            Evaluacion = new Collection<Evaluacion>();
        }
    }
}
