﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class EquipoCelular
    {
        public int EquipoCelularId { get; set; }

        public AdministradorEquipo AdministradorEquipo { get; set; }
        public int AdministradorEquipoId { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionId { get; set; }
    }
}
