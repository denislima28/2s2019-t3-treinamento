using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace razor.Dominios
{
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {
        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Defeitos> Defeitos { get; set; }
        public virtual DbSet<RegistrosDefeitos> RegistrosDefeitos { get; set; }
        public virtual DbSet<TiposEquipamentos> TiposEquipamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress; Initial Catalog=DENIS_TREINAMENTO_LANHOUSE; user id=sa; password=info@132;");   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Defeitos>(entity =>
            {
                entity.ToTable("DEFEITOS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__DEFEITOS__E2AB1FF4937546AA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistrosDefeitos>(entity =>
            {
                entity.ToTable("REGISTROS_DEFEITOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataDefeito)
                    .HasColumnName("DATA_DEFEITO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefeitoId).HasColumnName("DEFEITO_ID");

                entity.Property(e => e.Observacao)
                    .HasColumnName("OBSERVACAO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEquipamentoId).HasColumnName("TIPO_EQUIPAMENTO_ID");

                entity.HasOne(d => d.Defeito)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.DefeitoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROS__DEFEI__5DCAEF64");

                entity.HasOne(d => d.TipoEquipamento)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.TipoEquipamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROS__TIPO___5CD6CB2B");
            });

            modelBuilder.Entity<TiposEquipamentos>(entity =>
            {
                entity.ToTable("TIPOS_EQUIPAMENTOS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TIPOS_EQ__E2AB1FF4CA4FECD1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF72407CDA438")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
