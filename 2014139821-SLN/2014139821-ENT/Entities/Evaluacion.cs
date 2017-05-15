using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Evaluacion
    {
        public TipoEvaluacion TipoEvaluacion { get; set; }

        public EstadoEvaluacion EstadoEvaluacion { get; set; }

        public Trabajador Trabajador { get; set; }

        public Plan Plan { get; set; }

        public Cliente Cliente { get; set; }

        public EquipoCelular EquipoCelular { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public CentroAtencion CentroAtencion { get; set; }


        
        public Evaluacion()
        {
            TipoEvaluacion = new TipoEvaluacion();
            EstadoEvaluacion = new EstadoEvaluacion();
            EquipoCelular = new EquipoCelular();
        }

        public Evaluacion(Plan plan, Cliente cliente, Trabajador trabajador, LineaTelefonica lineaTelefonica,CentroAtencion centroAtencion)
        {
            Plan = plan;
            Cliente = cliente;
            Trabajador = trabajador;
            LineaTelefonica = lineaTelefonica;
            CentroAtencion = centroAtencion;
        }


    }
}
