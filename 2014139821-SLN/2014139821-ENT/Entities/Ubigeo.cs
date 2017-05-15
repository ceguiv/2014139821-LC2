using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Ubigeo
    {
        public Distrito Distrito { get; set; }

        public Provincia Provincia { get; set; }

        public Departamento Departamento { get; set; }

        public Ubigeo()
        {

        }

        public Ubigeo(Distrito distrito, Provincia provincia, Departamento departamento)
        {
            Distrito = distrito;
            Provincia = provincia;
            Departamento = departamento;
        }
    }
}
