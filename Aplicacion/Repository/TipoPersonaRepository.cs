using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
{
    protected readonly DbFirstContext _context;

    public TipoPersonaRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.TipoPersonas
            .ToListAsync();
    }

    public override async Task<TipoPersona> GetByIdAsync(string id)
    {
        return await _context.TipoPersonas
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}