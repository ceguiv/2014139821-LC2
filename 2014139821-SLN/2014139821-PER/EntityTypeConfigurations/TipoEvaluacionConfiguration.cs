using _2014139821_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.EntityTypeConfigurations
{
    public class TipoEvaluacionConfiguration : EntityTypeConfiguration<TipoEvaluacion>
    {
        public TipoEvaluacionConfiguration()
        {
            ToTable("TipoEvaluacion");
            HasKey(a => a.TipoEvaluacionId);

        }
    }
}
