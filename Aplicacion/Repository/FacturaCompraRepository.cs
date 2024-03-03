using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class FacturaCompraRepository : GenericRepository<FacturaCompra>, IFacturaCompra
{
    protected readonly DbFirstContext _context;

    public FacturaCompraRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<FacturaCompra>> GetAllAsync()
    {
        return await _context.FacturaCompras
            .Include(p => p.IdEmpleadoFkNavigation)
            .Include(p => p.IdProductoFkNavigation)
            .Include(p => p.IdProveedorFkNavigation)
            .Include(p => p.IdTipoPagoFkNavigation)
            .ToListAsync();
    }

    public override async Task<FacturaCompra> GetByIdAsync(string id)
    {
        return await _context.FacturaCompras
            .Include(p => p.IdEmpleadoFkNavigation)
            .Include(p => p.IdProductoFkNavigation)
            .Include(p => p.IdProveedorFkNavigation)
            .Include(p => p.IdTipoPagoFkNavigation)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}