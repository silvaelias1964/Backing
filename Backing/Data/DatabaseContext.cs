using Backing.Models;
using Backing.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Backing.Data
{    
    public partial class DatabaseContext : DbContext
    {
 
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario  { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<CriptoMoneda> CriptoMoneda { get; set; }
        public virtual DbSet<PrecioCripto> PrecioCripto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.UsrId).IsUnique();                
            });

            builder.Entity<Moneda>(entity =>
            {
                entity.HasIndex(e => e.MonId).IsUnique();
            });

            builder.Entity<CriptoMoneda>(entity =>
            {
                entity.HasIndex(e => e.CrmId).IsUnique();
            });

            builder.Entity<PrecioCripto>(entity =>
            {
                entity.HasIndex(e => e.PrcId).IsUnique();
            });
            
            builder.Entity<PrecioCripto>()            
                .HasOne(p => p.CriptoMoneda)
                .WithMany(c => c.PrecioCripto)
                .HasForeignKey(p => p.CrmId);
            
            builder.Entity<PrecioCripto>()
                .HasOne(p => p.Moneda)
                .WithMany(m => m.PrecioCripto)
                .HasForeignKey(p => p.MonId);

            // Atributos de campo
            builder.Entity<PrecioCripto>()
                .Property(p => p.PrcPrecio)
                .HasColumnType("decimal(18,2)");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


    }

}
