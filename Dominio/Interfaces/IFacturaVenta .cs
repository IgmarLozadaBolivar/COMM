using Dominio.Entidades;
namespace Dominio.Interfaces;

public interface IFacturaVenta : IGenericRepository<FacturaVenta>
{
Task<IEnumerable<FacturaVenta>> MesXFacturaVenta(string FechaCompra);
}