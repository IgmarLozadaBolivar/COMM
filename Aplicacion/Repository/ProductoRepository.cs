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
            .ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<Producto> GetNombreAsync(string Nombre)
    {
        return await _context.Productos
            .FirstOrDefaultAsync(p => p.Nombre == Nombre);
    }
}