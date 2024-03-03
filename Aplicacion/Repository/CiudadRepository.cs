using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    protected readonly DbFirstContext _context;

    public CiudadRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades
            .ToListAsync();
    }

    public override async Task<Ciudad> GetByIdAsync(string id)
    {
        return await _context.Ciudades
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}