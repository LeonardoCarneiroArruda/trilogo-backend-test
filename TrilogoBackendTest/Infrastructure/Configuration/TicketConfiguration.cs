using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("ticket");
            builder.HasKey(e => e.Id)
                   .HasName("pk_usuario");
            builder.Property(e => e.AuthorName)
                   .HasColumnName("authorname")
                   .IsRequired();
            builder.Property(e => e.Date)
                   .HasColumnName("date")
                   .IsRequired();
            builder.Property(e => e.Description)
                   .HasColumnName("description")
                   .IsRequired();

            //DomainBase
            builder.Property(e => e.DataCadastro)
                   .HasColumnName("datacadastro")
                   .IsRequired();
            builder.Property(e => e.DataEdicao)
                   .HasColumnName("dataedicao");
        }
    }
}
