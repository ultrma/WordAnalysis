using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WordAnalysis.DataAccess.Models;

#nullable disable

namespace WordAnalysis.DataAccess
{
    public partial class WordAnalysisContext : DbContext
    {
        public WordAnalysisContext()
        {
        }

        public WordAnalysisContext(DbContextOptions<WordAnalysisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertiser> Advertisers { get; set; }
        public virtual DbSet<Alias> Aliases { get; set; }
        public virtual DbSet<DuplicatedAdvertiser> DuplicatedAdvertisers { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=WordAnalysis;User ID=sa;Password=Pwd!2345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Advertiser>(entity =>
            {
                entity.ToTable("Advertiser");

                entity.HasIndex(e => e.Name, "UIDX_NAME")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Alias>(entity =>
            {
                entity.ToTable("Alias");

                entity.HasIndex(e => e.Name, "IDX_ALIAS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
