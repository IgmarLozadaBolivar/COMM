using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly DbFirstContext _context;

    public PersonaRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .Include(p => p.FacturaCompras)
            .Include(p => p.FacturaVentas)
            .Include(p => p.IdTipoPersonaFkNavigation)
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(string id)
    {
        return await _context.Personas
            .Include(p => p.FacturaCompras)
            .Include(p => p.FacturaVentas)
            .Include(p => p.IdTipoPersonaFkNavigation)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}