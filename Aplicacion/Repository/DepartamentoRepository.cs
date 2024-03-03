using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    protected readonly DbFirstContext _context;

    public DepartamentoRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
            .Include(p => p.Ciudades)
            .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(string id)
    {
        return await _context.Departamentos
            .Include(p => p.Ciudades)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
    }
}