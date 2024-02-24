using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComidaRapida.Data
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
  
        public int Numero { get; set; }
        public string Destino { get; set; } = "";
        public string Cliente { get; set; } = "";
        public DateTime Fecha { get; set; }
        public ICollection<FacturaDetalle> Detalles { get; set; }
        = new HashSet<FacturaDetalle>();
        [NotMapped]
        public decimal Total => (Detalles != null && Detalles.Any()) ? Detalles.Sum(d => d.SubTotal) : 0;
    }

}
