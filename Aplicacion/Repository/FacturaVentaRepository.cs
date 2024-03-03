using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class FacturaVentaRepository : GenericRepository<FacturaVenta>, IFacturaVenta
{
    protected readonly DbFirstContext _context;

    public FacturaVentaRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<FacturaVenta>> GetAllAsync()
    {
        return await _context.FacturaVentas
            .Include(p => p.IdEmpleadoFkNavigation)
            .Include(p => p.IdProductoFkNavigation)
            .Include(p => p.IdTipoPagoFkNavigation)
            .ToListAsync();
    }

    public override async Task<FacturaVenta> GetByIdAsync(string id)
    {
        return await _context.FacturaVentas
            .Include(p => p.IdEmpleadoFkNavigation)
            .Include(p => p.IdProductoFkNavigation)
            .Include(p => p.IdTipoPagoFkNavigation)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}