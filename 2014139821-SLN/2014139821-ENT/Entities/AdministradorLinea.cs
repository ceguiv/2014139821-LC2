using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class AdministradorLinea
    {
        public LineaTelefonica LineaTelefonica { get; set; }

        public AdministradorLinea()
        {
            LineaTelefonica = new LineaTelefonica();
        }

    }
}
