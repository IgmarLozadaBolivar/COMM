using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class CompraProductoRepository : GenericRepository<CompraProducto>, ICompraProducto
{
    protected readonly DbFirstContext _context;

    public CompraProductoRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CompraProducto>> GetAllAsync()
    {
        return await _context.CompraProductos
           //.Include(p => p.)
           .ToListAsync();
    }

    public override async Task<CompraProducto> GetByIdAsync(int id)
    {
        return await _context.CompraProductos
           //.Include(p => p.)
           .FirstOrDefaultAsync(p => p.Id == id);
    }
}