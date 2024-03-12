namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Roles { get; }

    ICategoria Categorias { get; }
    IFacturaCompra FacturaCompras { get; }
    IFacturaVenta FacturaVentas { get; }
    IPersona Personas { get; }
    IProducto Productos { get; }
    IProveedor Proveedores { get; }
    
    Task<int> SaveAsync();
}