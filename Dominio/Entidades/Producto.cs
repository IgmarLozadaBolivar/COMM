﻿namespace Dominio.Entidades;

public class Producto : BaseEntity
{
 
    public string Nombre { get; set; }
    public decimal Precio { get; set; } = 0.00m;
    public string UsoClinico { get; set; }
    public int CodigoBarras { get; set; }
    public string Marca { get; set; }
    public string Descripcion { get; set; }
    public string Presentacion { get; set; }
    public int TotalExistencias { get; set; }
    public string Categoria {get; set;}

    public virtual ICollection<FacturaCompra> FacturaCompras { get; set; } = new List<FacturaCompra>();
    public virtual ICollection<FacturaVenta> FacturaVentas { get; set; } = new List<FacturaVenta>();
   
}