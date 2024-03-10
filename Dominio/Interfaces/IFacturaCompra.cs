using Dominio.Entidades;
namespace Dominio.Interfaces;

public interface IFacturaCompra : IGenericRepository<FacturaCompra>
{
 Task<IEnumerable<FacturaCompra>> MesXFacturaCompra(string FechaCompra) ;
}