using ComidaRapida.Data;

using ComidaRapida.Pages;

namespace ComidaRapida.Services
{
    public class ComidaService : IComidaService
    {
        //Metodo para consultar las facturas..
        public List<Factura> Consultar(string filtro) => Memoria
            .Facturas.Where(c => c.Cliente.Contains(filtro)).ToList();
        //Metodo para guardar la factura...
        public bool Crear(Factura data)
        {
            try
            {
                var nombre = (Memoria.Facturas != null && Memoria.Facturas.Any()) ?
                Memoria.Facturas.Max(n => n.Numero) + 1 : 1;
                data.Numero = nombre;
                data.Fecha = DateTime.Now;
                Memoria.Facturas?.Add(data);
                return true;
            }
            catch
            {
                return false;
            }
           

        }
    }
}
