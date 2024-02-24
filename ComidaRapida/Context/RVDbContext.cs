using ComidaRapida.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ComidaRapida.Context;

public class RVDbContext : DbContext, IRVDbContext
{
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturasDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "RVDbContext.db" };
        var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, connectionStringBuilder.DataSource);
        connectionStringBuilder.DataSource = databasePath;

        optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
    }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}