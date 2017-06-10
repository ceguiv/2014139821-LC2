using _2014139821_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.EntityTypeConfigurations
{
    public class EquipoCelularConfiguration : EntityTypeConfiguration<EquipoCelular>
    {
        public EquipoCelularConfiguration()
        {
            ToTable("EquipoCelular");
            HasKey(a => a.EquipoCelularId);

            HasRequired(a => a.AdministradorEquipo)
                .WithMany(e => e.EquipoCelular)
                .HasForeignKey(a => a.AdministradorEquipoId);


        }
    }
}
