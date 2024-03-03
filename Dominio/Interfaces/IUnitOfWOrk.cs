namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Roles { get; }

    IDepartamento Departamentos { get; }
    ICiudad Ciudades { get; }
    ICategoria Categorias { get; }
    IFacturaCompra FacturaCompras { get; }
    IFacturaVenta FacturaVentas { get; }
    IPersona Personas { get; }
    IProducto Productos { get; }
    IProveedor Proveedores { get; }
    ITipoPago TipoPagos { get; }
    ITipoPersona TipoPersonas { get; }
    
    Task<int> SaveAsync();
}