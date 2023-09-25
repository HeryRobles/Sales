using Microsoft.EntityFrameworkCore;
using SalesShared.Entities;
using SalesShared.Entities.Productos;

namespace SalesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> CategoriasProductos { get; set; }
        public DbSet<ClasificacionProducto> ClasificacionProductos { get; set; }

        public DbSet<ProductoImg> ImgProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Categoria>().HasIndex(x => x.NombreCategoria).IsUnique();
            modelBuilder.Entity<ClasificacionProducto>().HasIndex(x => x.NombreClasificacion).IsUnique();
            modelBuilder.Entity<Producto>().HasIndex(x => x.Nombre).IsUnique();

            // Relación entre ClasificacionProducto y Producto (uno a muchos)
            modelBuilder.Entity<ClasificacionProducto>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.ClasificacionProducto)
                .HasForeignKey(p => p.ClasificacionProductoId);

            //Relación entre Categoria y ClasificacionProducto (uno a muchos)
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.ClasificacionProductos)
                .WithOne(cp => cp.Categoria)
                .HasForeignKey(cp => cp.CategoriaId);

            //modelBuilder.Entity<ClasificacionProducto>().HasIndex("CategoriaId", "NombreCategoria").IsUnique();
            //modelBuilder.Entity<Producto>().HasIndex("ClasificacionCategoriaId", "NombreClasificacion").IsUnique();
        }

    }
}
