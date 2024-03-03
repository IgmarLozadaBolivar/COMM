using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;
namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbFirstContext context;
    private UserRepository _usuarios;
    private RolRepository _roles;
    
    private CategoriaRepository _categorias;
    private DepartamentoRepository _departamentos;
    private CiudadRepository _ciudades;
    private FacturaCompraRepository _facturaCompras;
    private FacturaVentaRepository _facturaVentas;
    private PersonaRepository _personas;
    private ProductoRepository _productos;
    private ProveedorRepository _proveedores;
    private TipoPagoRepository _tipoPagos;
    private TipoPersonaRepository _tipoPersonas;
    
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

    public ICategoria Categorias
    {
        get
        {
            if (_categorias == null)
            {
                _categorias = new CategoriaRepository(context);
            }
            return _categorias;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(context);
            }
            return _departamentos;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(context);
            }
            return _ciudades;
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

    public ITipoPago TipoPagos
    {
        get
        {
            if (_tipoPagos == null)
            {
                _tipoPagos = new TipoPagoRepository(context);
            }
            return _tipoPagos;
        }
    }

    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersonas == null)
            {
                _tipoPersonas = new TipoPersonaRepository(context);
            }
            return _tipoPersonas;
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