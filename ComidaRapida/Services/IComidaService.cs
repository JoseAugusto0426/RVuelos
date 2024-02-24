using ComidaRapida.Data;

namespace ComidaRapida.Services
{
    public interface IComidaService
    {
        List<Factura> Consultar(string filtro);
        bool Crear(Factura data);
    }
}