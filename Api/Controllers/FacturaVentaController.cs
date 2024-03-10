using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

public class FacturaVentaController : BaseApiController
{
    private readonly IUnitOfWork unitOfwork;
    private readonly IMapper mapper;

    public FacturaVentaController(IUnitOfWork unitOfwork, IMapper mapper)
    {
        this.unitOfwork = unitOfwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FacturaVenta>>> Get()
    {
        var datos = await unitOfwork.FacturaVentas.GetAllAsync();
        return Ok(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FacturaVentaDto>> Get(int id)
    {
        var data = await unitOfwork.FacturaVentas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<FacturaVentaDto>(data);
    }
 [HttpGet("MesXFacturaVenta")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FacturaVentaDto>>> MesXFacturaVenta(string FechaVenta)
    {

        var facturas = await unitOfwork.FacturaVentas.MesXFacturaVenta(FechaVenta);

        if (facturas == null || !facturas.Any())
        {
            return NotFound();
        }

        var facturasDto = mapper.Map<IEnumerable<FacturaVentaDto>>(facturas);

        return Ok(facturasDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FacturaVentaDto>> Post(FacturaVentaDto dataDto)
    {
        var data = mapper.Map<FacturaVenta>(dataDto);
        unitOfwork.FacturaVentas.Add(data);
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
    public async Task<ActionResult<FacturaVentaDto>> Put(int id, [FromBody] FacturaVentaDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<FacturaVenta>(dataDto);
        unitOfwork.FacturaVentas.Update(data);
        await unitOfwork.SaveAsync();
        return dataDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfwork.FacturaVentas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfwork.FacturaVentas.Remove(data);
        await unitOfwork.SaveAsync();
        return NoContent();
    }
}