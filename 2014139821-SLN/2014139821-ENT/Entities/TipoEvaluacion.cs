﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class TipoEvaluacion
    {
        public int TipoEvaluacionId { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionId { get; set; }


        public TipoEvaluacion()
        {
            Evaluacion = new Collection<Evaluacion>();
        }
    }
}
