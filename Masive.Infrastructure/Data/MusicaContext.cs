using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MasiveApi.Api.Data
{
    public partial class MusicaContext : DbContext
    {
        public MusicaContext()
        {
        }

        public MusicaContext(DbContextOptions<MusicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detalles> Detalles { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IUDOEOQ\\SANTINO;Database=Musica;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__CB903349D4D27532");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("Id_Categoria")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__3DD0A8CB3B997769");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("Id_Cliente")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido2).HasMaxLength(20);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Nombre2).HasMaxLength(20);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__Id_Usua__267ABA7A");
            });

            modelBuilder.Entity<Detalles>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PK__Detalles__9274780B0EBE89C6");

                entity.Property(e => e.IdDetalle)
                    .HasColumnName("Id_Detalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoFactura).HasColumnName("Codigo_factura");

                entity.Property(e => e.FechaCompra)
                    .HasColumnName("Fecha_compra")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.PrecioTotal).HasColumnName("Precio_total");

                entity.HasOne(d => d.CodigoFacturaNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.CodigoFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalles__Codigo__412EB0B6");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalles__Id_Pro__403A8C7D");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.CodigoFactura)
                    .HasName("PK__Factura__90794BC07B66CD03");

                entity.Property(e => e.CodigoFactura)
                    .HasColumnName("Codigo_factura")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura__Id_Clie__2A4B4B5E");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__2085A9CF1F7E32EE");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__Id_Ca__398D8EEE");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE2A387BFCD");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
