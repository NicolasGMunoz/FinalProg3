using Microsoft.EntityFrameworkCore;
using UTN.Inc.Entities;

namespace APIStock.Context
{
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venta> Venta { get; set; }
    }
}