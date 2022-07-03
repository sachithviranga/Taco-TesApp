using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PrintCost.Context
{
    public partial class PrintCostContext : DbContext
    {
        public PrintCostContext()
        {
        }

        public PrintCostContext(DbContextOptions<PrintCostContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PcJobType> PcJobType { get; set; }
        public virtual DbSet<PcPaperSize> PcPaperSize { get; set; }
        public virtual DbSet<PcPrice> PcPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PcJobType>(entity =>
            {
                entity.ToTable("PC_JobType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PcPaperSize>(entity =>
            {
                entity.ToTable("PC_PaperSize");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PcPrice>(entity =>
            {
                entity.ToTable("PC_Price");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PcJobTypeId).HasColumnName("PC_JobTypeId");

                entity.Property(e => e.PcPaperSizeId).HasColumnName("PC_PaperSizeId");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.PcJobType)
                    .WithMany(p => p.PcPrice)
                    .HasForeignKey(d => d.PcJobTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_Price_PC_JobTypeId");

                entity.HasOne(d => d.PcPaperSize)
                    .WithMany(p => p.PcPrice)
                    .HasForeignKey(d => d.PcPaperSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_Price_PC_PaperSizeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
