using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class TipoPagoRepository : GenericRepository<TipoPago>, ITipoPago
{
    protected readonly DbFirstContext _context;

    public TipoPagoRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoPago>> GetAllAsync()
    {
        return await _context.TipoPagos
            .Include(p => p.FacturaCompras)
            .Include(p => p.FacturaVentas)
            .ToListAsync();
    }

    public override async Task<TipoPago> GetByIdAsync(string id)
    {
        return await _context.TipoPagos
            .Include(p => p.FacturaCompras)
            .Include(p => p.FacturaVentas)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}