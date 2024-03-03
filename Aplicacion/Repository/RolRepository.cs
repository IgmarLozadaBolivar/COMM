using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    protected readonly DbFirstContext _context;
    
    public RolRepository(DbFirstContext context) : base (context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Rols
            .ToListAsync();
    }
    
    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Rols
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}