﻿using _2014139821_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_PER.EntityTypeConfigurations
{
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            ToTable("Distrito");
            HasKey(a => a.DistritoId);

            HasRequired(a => a.Provincia)
                .WithMany(a => a.Distritos)
                .HasForeignKey(a => a.ProvinciaId);
        }
    }
}
