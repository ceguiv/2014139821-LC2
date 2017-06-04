using _2014139821_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.EntityTypeConfigurations
{
    public class LineaTelefonicaConfiguration : EntityTypeConfiguration<LineaTelefonica>
    {
        public LineaTelefonicaConfiguration()
        {
            ToTable("LineaTelefonica");
            HasKey(a => a.LineaTelefonicaId);

            HasRequired(a => a.AdministradorLinea)
                .WithMany(a => a.LineaTelefonica)
                .HasForeignKey(a => a.AdministradorLineaId);

            HasRequired(a => a.TipoLinea)
                .WithMany(a => a.LineaTelefonica);

        }
    }
}
