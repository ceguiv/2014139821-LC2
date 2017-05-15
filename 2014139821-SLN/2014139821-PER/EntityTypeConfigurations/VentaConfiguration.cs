using _2014139821_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.EntityTypeConfigurations
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {

        public VentaConfiguration()
        {
            
            //Relacion DE VUELTA (1 a *) - TIPO PAGO
            HasRequired(v => v.TipoPago)
                .WithMany(g => g.Ventas);

            //RELACION DE VUELTA (* a *) - CENTRO ATENCION
           


        }
    }
}
