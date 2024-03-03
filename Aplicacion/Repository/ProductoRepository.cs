using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    protected readonly DbFirstContext _context;

    public ProductoRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.FacturaCompras)
            .Include(p => p.FacturaVentas)
            .Include(p => p.IdCategoriaFkNavigation)
            .ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Productos
            .Include(p => p.FacturaCompras)
            .Include(p => p.FacturaVentas)
            .Include(p => p.IdCategoriaFkNavigation)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}