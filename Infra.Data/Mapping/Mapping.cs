    using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Email)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Password)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("varchar(100)");
        }
    }

    public class AssistenciaMap : IEntityTypeConfiguration<Assistencia>
    {
        public void Configure(EntityTypeBuilder<Assistencia> builder)
        {
            builder.ToTable("Assistencia");

            builder.HasKey(prop => prop.assistencia_id);
           // builder.Property(prop => prop.assistencia_id)
           //     .IsRequired()
           //     .HasColumnName("assistencia_id")
           //     .HasColumnType("int(11)");

            builder.Property(prop => prop.actualStart)
                .IsRequired()
                .HasColumnName("actualstart")
                .HasColumnType("Datetime");

            builder.Property(prop => prop.actualEnd)
                .IsRequired()
                .HasColumnName("actualend")
                .HasColumnType("Datetime");

            builder.Property(prop => prop.pjo_tipodeatividade)
               .IsRequired()
               .HasColumnName("pjo_tipodeatividade")
               .HasColumnType("int(11)");

            builder.Property(prop => prop.description)
               .IsRequired()
               .HasColumnName("description")
               .HasColumnType("varchar(255)");

            builder.Property(prop => prop.pjo_empreendimentoid)
                .IsRequired()
                .HasColumnName("pjo_empreendimentoid")
                .HasColumnType("int(11)");

            builder.Property(prop => prop.pjo_blocoid)
                .IsRequired()
                .HasColumnName("pjo_blocoid")
                .HasColumnType("int(11)");

            builder.Property(prop => prop.pjo_unidadeid)
                .IsRequired()
                .HasColumnName("pjo_unidadeid")
                .HasColumnType("int(11)");
        }
    }

}

