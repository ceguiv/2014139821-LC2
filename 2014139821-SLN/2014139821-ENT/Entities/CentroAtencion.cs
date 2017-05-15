using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class CentroAtencion
    {
        public Direccion Direccion { get; set; }

        public CentroAtencion()
        {
            Direccion = new Direccion();
        }
    }
}
