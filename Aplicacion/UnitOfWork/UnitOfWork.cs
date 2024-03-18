using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;
namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbFirstContext context;
    private UserRepository _usuarios;
    private RolRepository _roles;
    
   
    private FacturaCompraRepository _facturaCompras;
    private FacturaVentaRepository _facturaVentas;
    private PersonaRepository _personas;
    private ProductoRepository _productos;
    private ProveedorRepository _proveedores;
    private VentaProductoRepository _ventaProductos;
    private CompraProductoRepository _compraProductos;
    
    public UnitOfWork(DbFirstContext _context)
    {
        context = _context;
    }
     
    public IUser Users
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UserRepository(context);
            }
            return _usuarios;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(context);
            }
            return _roles;
        }
    }

    

    public IFacturaCompra FacturaCompras
    {
        get
        {
            if (_facturaCompras == null)
            {
                _facturaCompras = new FacturaCompraRepository(context);
            }
            return _facturaCompras;
        }
    }

    public IFacturaVenta FacturaVentas
    {
        get
        {
            if (_facturaVentas == null)
            {
                _facturaVentas = new FacturaVentaRepository(context);
            }
            return _facturaVentas;
        }
    }

    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepository(context);
            }
            return _personas;
        }
    }

    public IProducto Productos
    {
        get
        {
            if (_productos == null)
            {
                _productos = new ProductoRepository(context);
            }
            return _productos;
        }
    }

    public IProveedor Proveedores
    {
        get
        {
            if (_proveedores == null)
            {
                _proveedores = new ProveedorRepository(context);
            }
            return _proveedores;
        }
    }

    public IVentaProducto VentasProductos
    {
        get
        {
            if (_ventaProductos == null)
            {
                _ventaProductos = new VentaProductoRepository(context);
            }
            return _ventaProductos;
        }
    }

    public ICompraProducto ComprasProductos
    {
        get
        {
            if (_compraProductos == null)
            {
                _compraProductos = new CompraProductoRepository(context);
            }
            return _compraProductos;
        }
    }
    
    public void Dispose()
    {
        context.Dispose();
    }
    
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}