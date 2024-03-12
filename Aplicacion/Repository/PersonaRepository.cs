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
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<Persona> GetNombreAsync(string Nombre)
    {
        return await _context.Personas
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Nombre == Nombre);
    }
}