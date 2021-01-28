using Domain;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Data;

namespace Infrastructure
{
    public class TrilogoContext : DbContext, IConnectionFactory
    {

        public const string ConnectionString = "Server=127.0.0.1;Database=trilogo;Port=7071;UserId=postgres;Password=123456;Pooling=true;";

        public DbSet<Ticket> Ticket { get; set; }


        public TrilogoContext(DbContextOptions<TrilogoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseNpgsql(ConnectionString, o => o.SetPostgresVersion(9, 6));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }

        public IDbConnection ConnectionRead()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
