using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Plan
    {
        public TipoPlan TipoPlan { get; set; }

        public Plan()
        {
            TipoPlan = new TipoPlan();
        }
    }
}
