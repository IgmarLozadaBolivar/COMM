using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
{
    protected readonly DbFirstContext _context;

    public RefreshTokenRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<RefreshToken>> GetAllAsync()
    {
        return await _context.RefreshTokens
           //.Include(p => p.)
           .ToListAsync();
    }

    public override async Task<RefreshToken> GetByIdAsync(int id)
    {
        return await _context.RefreshTokens
           //.Include(p => p.)
           .FirstOrDefaultAsync(p => p.Id == id);
    }
}