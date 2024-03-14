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
            .Include(p => p.IdProveedorFkNavigation)
            .ToListAsync();
    }

    public override async Task<FacturaCompra> GetByIdAsync(string id)
    {
        return await _context.FacturaCompras
            .Include(p => p.IdProveedorFkNavigation)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }

    public async Task<IEnumerable<FacturaCompra>> MesXFacturaCompra(string FechaCompraStr)
    {

        if (!DateTime.TryParse(FechaCompraStr, out DateTime FechaCompra))
        {
            throw new ArgumentException("Formato de fecha incorrecto. Utilice el formato adecuado.");
        }
        var factura = await _context.FacturaCompras
            .Where(factura => factura.FechaCompra.Month == FechaCompra.Month && factura.FechaCompra.Year == FechaCompra.Year)
            .Select(factura => new FacturaCompra
            {
                FechaCompra = factura.FechaCompra,
                IdProveedorFkNavigation = factura.IdProveedorFkNavigation,
                CantidadTotal = factura.CantidadTotal,
                PrecioTotal = factura.PrecioTotal,
            })
            .ToListAsync();
        return factura;
    }
}