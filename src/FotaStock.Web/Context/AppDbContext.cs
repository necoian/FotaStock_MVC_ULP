using Microsoft.EntityFrameworkCore;
using FotaStock.Web.Entities;

namespace FotaStock.Web.Context;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<ArchivoImagen> ArchivoImagen {get;set;}

    public DbSet<Categoria> Categoria {get;set;}

    public DbSet<Compra> Compra {get;set;}

    public DbSet<DetalleCompra> DetalleCompra {get;set;}

    public DbSet<Imagen> Imagen {get;set;}

    public DbSet<Licencia> Licencia {get;set;}

    public DbSet<OfertaLicencia> OFertaLicencia {get;set;}

    public DbSet<Pago> Pago {get;set;}

    public DbSet<Usuario> Usuario {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ArchivoImagen>(e =>
        {
            
            e.HasKey("ArchivoImagenId");
            e.Property("ArchivoImagenId").ValueGeneratedOnAdd();
            e.HasOne(e => e.Imagen).WithMany(p => p.ArchivoImagenes).HasForeignKey(e => e.ImagenId).OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<Categoria>(e =>
        {
            
            e.HasKey("CategoriaId");
            e.Property("CategoriaId").ValueGeneratedOnAdd();
            e.HasData(
                new Categoria { CategoriaId = 1, Nombre = "Hiperrealista", Descripcion = "Es el arte de copiar de la manera más precisa la realidad y plasmarlo con las tecnicas de dibujo o pintura que el artista crea adecuado"}
            );
            
        });

        modelBuilder.Entity<Compra>(e =>
        {
            
            e.HasKey("CompraId");
            e.Property("CompraId").ValueGeneratedOnAdd();
            e.Property("Total").HasColumnType("decimal(10,2)");
            e.HasOne(e => e.Usuario).WithMany(p => p.Compras).HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DetalleCompra>(e =>
        {
            
            e.HasKey("DetalleCompraId");
            e.Property("DetalleCompraId").ValueGeneratedOnAdd();
            e.Property("PrecioUnitario").HasColumnType("decimal(10,2)");
            e.HasOne(e => e.Compra).WithMany(p => p.DetalleCompras).HasForeignKey(e => e.CompraId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(e => e.OfertaLicencia).WithMany(p=> p.DetalleCompras).HasForeignKey(e => e.OfertaLicenciaId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Imagen>(e =>
        {
            
            e.HasKey("ImagenId");
            e.Property("ImagenId").ValueGeneratedOnAdd();
            e.HasOne(e => e.Categoria).WithMany(p => p.Imagenes).HasForeignKey(e => e.CategoriaId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(e => e.Usuario).WithMany(p => p.Imagenes).HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            
        });

        modelBuilder.Entity<Licencia>(e =>
        {
            
            e.HasKey("LicenciaId");
            e.Property("LicenciaId").ValueGeneratedOnAdd();
            e.HasOne(e => e.DetalleCompra).WithMany(p => p.Licencias).HasForeignKey(e => e.DetalleCompraId).OnDelete(DeleteBehavior.Restrict);        });

        modelBuilder.Entity<OfertaLicencia>(e =>
        {
            
            e.HasKey("OfertaLicenciaId");
            e.Property("OfertaLicenciaId").ValueGeneratedOnAdd();
            e.Property("Precio").HasColumnType("decimal(10,2)");
            e.HasOne(e => e.Imagen).WithMany(p => p.OfertaLicencias).HasForeignKey(e => e.ImagenId).OnDelete(DeleteBehavior.Restrict);
            

        });

        modelBuilder.Entity<Pago>(e =>
        {
            
            e.HasKey("PagoId");
            e.Property("PagoId").ValueGeneratedOnAdd();
            e.Property("Monto").HasColumnType("decimal(10,2)");
            e.HasOne(e => e.Compra).WithMany(p => p.Pagos).HasForeignKey(e => e.CompraId).OnDelete(DeleteBehavior.Cascade);
            
        });

        modelBuilder.Entity<Usuario>(e =>
        {
            
            e.HasKey("UsuarioId");
            e.Property("UsuarioId").ValueGeneratedOnAdd();
            
        });



    }





}