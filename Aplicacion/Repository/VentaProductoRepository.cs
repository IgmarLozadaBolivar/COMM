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
                     join fv in _context.FacturaVentas on vp.IdFacturaVentaFK equals fv.Id
                     join c in _context.Personas on fv.IdClienteFk equals c.Id
                     join p in _context.Productos on vp.IdProductoFK equals p.Id
                     where vp.FechaVenta == fv.FechaVenta
                     select new
                     {
                        IdFacturaVentaFK = fv.Id,
                        IdProducto = p.Id,
                        FechaVenta = fv.FechaVenta,
                        NombreCliente = $"{c.Nombre} {c.Apellidos}",
                        CedulaCliente = c.Cedula,
                        CorreoCliente = c.Correo,
                        TelefonoCliente = c.Telefono,
                        TipoCliente = fv.TipoCliente,
                        Observacion = fv.Observacion,
                        NombreProducto = p.Nombre,
                        DescripcionProducto = p.Descripcion,
                        PresentacionProducto = p.Presentacion,
                        Cantidad = fv.Cantidad,
                        PrecioCompra = p.PrecioCompra,
                        PrecioVenta = p.PrecioVenta,
                        cantidadVendida = vp.CantidadVendida,
                        CodigoBarras = p.CodigoBarras,
                        PrecioTotal = fv.PrecioTotal,
                        TipoPago = fv.TipoPago
                     };

      var agrupadoPorFactura = consulta.GroupBy(vp => new
      {
         vp.IdFacturaVentaFK,
         vp.FechaVenta,
         vp.PrecioTotal,
         vp.TipoPago
      })
      .Select(grp => new
      {
         IdFacturaVentaFK = grp.Key.IdFacturaVentaFK,
         DatosDeFactura = grp.Select(d => new
         {
            FechaDeVenta = d.FechaVenta,
            PrecioTotal = d.PrecioTotal,
            TipoDePago = d.TipoPago,
            CantidadTotal = d.Cantidad
         }).First(),
         DatosDeCliente = grp.Select(c => new
         {
            NombreDelCliente = c.NombreCliente,
            CedulaDelCliente = c.CedulaCliente,
            CorreoDelCliente = c.CorreoCliente,
            TelefonoDelCliente = c.TelefonoCliente,
            TipoDeCliente = c.TipoCliente,
            ObservacionDelCliente = c.Observacion
         }).First(),
         VentasProductos = grp.Select(v => new
         {
            IdDelProducto = v.IdProducto,
            NombreDelProducto = v.NombreProducto,
            DescripcionDelProducto = v.DescripcionProducto,
            PresentacionDelProducto = v.PresentacionProducto,
            PrecioDeCompra = v.PrecioCompra,
            PrecioDeVenta = v.PrecioVenta,
            CodigoDeBarras = v.CodigoBarras,
            CantidadVendida = v.cantidadVendida
         }).ToList()
      });

      var resultado = await agrupadoPorFactura.ToListAsync();

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