using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Settimana_19_Esercizio_Unico.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext") { }

        public virtual DbSet<Articoli> Articoli { get; set; }
        public virtual DbSet<Dettagli_Ordini> Dettagli_Ordini { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>().Property(e => e.Prezzo).HasPrecision(19, 4);

            modelBuilder
                .Entity<Articoli>()
                .HasMany(e => e.Dettagli_Ordini)
                .WithRequired(e => e.Articoli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordini>().Property(e => e.Importo).HasPrecision(19, 4);

            modelBuilder
                .Entity<Ordini>()
                .HasMany(e => e.Dettagli_Ordini)
                .WithRequired(e => e.Ordini)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Utenti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Utenti)
                .WillCascadeOnDelete(false);
        }
    }
}
