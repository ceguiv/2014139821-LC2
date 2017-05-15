using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Provincia
    {
        public Distrito Distrito { get; set; }

        public Provincia()
        {
            Distrito = new Distrito();
        }
    }
}
