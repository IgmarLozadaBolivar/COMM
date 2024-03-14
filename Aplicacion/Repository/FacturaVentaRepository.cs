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
            .ToListAsync();
    }

    public override async Task<FacturaVenta> GetByIdAsync(string id)
    {
        return await _context.FacturaVentas
            .Include(p => p.IdEmpleadoFkNavigation)
            .Include(p => p.IdProductoFkNavigation)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }

    public async Task<IEnumerable<FacturaVenta>> MesXFacturaVenta(string FechaVentaStr)
    {
        if (!DateTime.TryParse(FechaVentaStr, out DateTime FechaVenta))
        {

            throw new ArgumentException("Formato de fecha incorrecto. Utilice el formato adecuado.");
        }

        var facturas = await _context.FacturaVentas
            .Where(factura => factura.FechaVenta.Month == FechaVenta.Month && factura.FechaVenta.Year == FechaVenta.Year)
            .Select(factura => new FacturaVenta
            {
                FechaVenta = factura.FechaVenta,
                IdEmpleadoFkNavigation = factura.IdEmpleadoFkNavigation,
                IdProductoFkNavigation = factura.IdProductoFkNavigation,
                Cantidad = factura.Cantidad,
                PrecioTotal = factura.PrecioTotal,
                Iva = factura.Iva
            })
            .ToListAsync();

        return facturas;
    }
}