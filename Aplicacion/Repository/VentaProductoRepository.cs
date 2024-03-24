using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;

public class VentaProductoRepository : GenericRepository<VentaProducto>, IVentaProducto
{
   protected readonly DbFirstContext _context;

   public VentaProductoRepository(DbFirstContext context) : base(context)
   {
      _context = context;
   }

   public async Task<object> DatosFacturaVenta()
   {
        var consulta = from vp in _context.VentaProductos
                       join p in _context.Productos on vp.IdProductoFK equals p.Id
                       join fv in _context.FacturaVentas on vp.IdFacturaVentaFK equals fv.Id
                       join ps in _context.Personas on vp.IdFacturaVentaFK equals ps.Id
                       select new
                       {
                           Nombre = p.Nombre,
                           Precio = p.Precio,
                           CodigoDeBarras = p.CodigoBarras,
                           Descripcion = p.Descripcion,
                           Presentacion = p.Presentacion,
                           TotalExistencias = p.TotalExistencias,
                           FechaDeVenta = fv.FechaVenta,
                           CantidadVendida = fv.Cantidad,
                           PrecioFactura = fv.PrecioTotal,
                           TipoPago = fv.TipoPago,
                           NombreCliente = ps.Nombre,
                           ApellidosCliente = ps.Apellidos,
                           CedulaCliente = ps.Cedula,
                           CorreoCliente = ps.Correo,
                           TelefonoCliente = ps.Telefono
                       };

        var resultado = await consulta.ToListAsync();
        return resultado;
   }

   public override async Task<IEnumerable<VentaProducto>> GetAllAsync()
   {
      return await _context.VentaProductos
         .Include(p => p.FacturaVenta)
         .Include(p => p.Producto)
         .ToListAsync();
   }

   public override async Task<VentaProducto> GetByIdAsync(int id)
   {
      return await _context.VentaProductos
         .Include(p => p.FacturaVenta)
         .Include(p => p.Producto)
         .FirstOrDefaultAsync(p => p.Id == id);
   }
}