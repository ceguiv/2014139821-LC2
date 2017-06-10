using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        public ICollection<Provincia> Provincia { get; set; }
        public int ProvinciaId { get; set; }

        public ICollection<Ubigeo> Ubigeo { get; set; }
        public int UbigeoId { get; set; }


        public Departamento()
        {

            Provincia = new Collection<Provincia>();
            Ubigeo = new Collection<Ubigeo>();
        }
    }
}
