namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Roles { get; }

   
    IFacturaCompra FacturaCompras { get; }
    IFacturaVenta FacturaVentas { get; }
    IPersona Personas { get; }
    IProducto Productos { get; }
    IProveedor Proveedores { get; }
    IVentaProducto VentasProductos { get; }
    ICompraProducto ComprasProductos { get; }

    IRefreshToken RefreshTokens { get; }
    
    Task<int> SaveAsync();
}