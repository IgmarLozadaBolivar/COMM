using Dominio.Entidades;
namespace Dominio.Interfaces;

public interface IVentaProducto : IGenericRepository<VentaProducto>
{
    Task<object> DatosFacturaVenta();
}