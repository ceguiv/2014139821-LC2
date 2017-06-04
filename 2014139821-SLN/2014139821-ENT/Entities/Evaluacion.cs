using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }

        public EstadoEvaluacion EstadoEvaluacion { get; set; }


        public TipoEvaluacion TipoEvaluacion { get; set; }


        public Cliente Cliente { get; set; }


        public Venta Venta { get; set; }
        public int VentaId { get; set; }


        public LineaTelefonica LineaTelefonica { get; set; }

        public EquipoCelular EquipoCelular { get; set; }

        public Plan Plan { get; set; }

        public Trabajador Trabajador { get; set; }
        public int TrabajadorId { get; set; }


        public CentroAtencion CentroAtencion { get; set; }
        public int CentroAtencionId { get; set; }


    }
}
