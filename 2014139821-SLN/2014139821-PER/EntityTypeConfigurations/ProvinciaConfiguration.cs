using _2014139821_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.EntityTypeConfigurations
{
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {

        public ProvinciaConfiguration()
        {
            ToTable("Provincia");
            HasKey(a => a.ProvinciaId);

            HasRequired(a => a.Departamento)
                .WithMany(a => a.Provincia)
                .HasForeignKey(a => a.DepartamentoId);
            
            
        }
    }
}
