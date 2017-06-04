using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Direccion
    {
        public int DireccionId { get; set; }


        public string CadenaUbigeo { get; set; }

        public CentroAtencion CentroAtencion { get; set; }

        public int CentroAtencionId { get; set; }

        public Distrito Distrito { get; set; }
        public int DistritoId { get; set; }

        public Ubigeo Ubigeo { get; set; }
    }
}
