using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    protected readonly DbFirstContext _context;

    public CategoriaRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Categorias
            .ToListAsync();
    }

    public override async Task<Categoria> GetByIdAsync(string id)
    {
        return await _context.Categorias
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}