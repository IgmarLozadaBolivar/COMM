using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

public class ProductoController : BaseApiController
{
    private readonly IUnitOfWork unitOfwork;
    private readonly IMapper mapper;

    public ProductoController(IUnitOfWork unitOfwork, IMapper mapper)
    {
        this.unitOfwork = unitOfwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Producto>>> Get()
    {
        var datos = await unitOfwork.Productos.GetAllAsync();
        return Ok(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> Get(int id)
    {
        var data = await unitOfwork.Productos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<ProductoDto>(data);
    }
    
    [HttpGet("MesXFacturaCompra")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FacturaCompraDto>>> MesXFacturaCompra(string FechaCompra)
    {

        var facturas = await unitOfwork.FacturaCompras.MesXFacturaCompra(FechaCompra);

        if (facturas == null || !facturas.Any())
        {
            return NotFound();
        }

        var facturasDto = mapper.Map<IEnumerable<FacturaCompraDto>>(facturas);

        return Ok(facturasDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> Post(ProductoDto dataDto)
    {
        var data = mapper.Map<Producto>(dataDto);
        unitOfwork.Productos.Add(data);
        await unitOfwork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        dataDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = dataDto.Id }, dataDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoDto>> Put(int id, [FromBody] ProductoDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<Producto>(dataDto);
        unitOfwork.Productos.Update(data);
        await unitOfwork.SaveAsync();
        return dataDto;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfwork.Productos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfwork.Productos.Remove(data);
        await unitOfwork.SaveAsync();
        return NoContent();
    }
}