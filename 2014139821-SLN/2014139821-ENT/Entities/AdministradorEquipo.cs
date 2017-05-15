using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class AdministradorEquipo
    {

        public List<EquipoCelular> EquipoCelulars { get; set; }

        public AdministradorEquipo()
        {
            EquipoCelulars = new List<EquipoCelular>();
        }
                
    }
}
