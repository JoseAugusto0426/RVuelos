using ComidaRapida.Context;
using ComidaRapida.Data;
using Microsoft.EntityFrameworkCore;

namespace ComidaRapida.Context
{
    public interface IRVDbContext
    {
          
        DbSet<Factura> Facturas { get; set; }
        DbSet<FacturaDetalle> FacturasDetalles { get; set; }

        int SaveChanges();
    }
}

