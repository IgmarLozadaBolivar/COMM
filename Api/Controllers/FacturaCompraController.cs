using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

public class FacturaCompraController : BaseApiController
{
    private readonly IUnitOfWork unitOfwork;
    private readonly IMapper mapper;

    public FacturaCompraController(IUnitOfWork unitOfwork, IMapper mapper)
    {
        this.unitOfwork = unitOfwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FacturaCompraDto>>> Get()
    {
        var data = await unitOfwork.FacturaCompras.GetAllAsync();
        return mapper.Map<List<FacturaCompraDto>>(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FacturaCompraDto>> Get(int id)
    {
        var data = await unitOfwork.FacturaCompras.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<FacturaCompraDto>(data);
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
    public async Task<ActionResult<FacturaCompraDto>> Post(FacturaCompraDto dataDto)
    {
        var data = mapper.Map<FacturaCompra>(dataDto);
        unitOfwork.FacturaCompras.Add(data);
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
    public async Task<ActionResult<FacturaCompraDto>> Put(int id, [FromBody] FacturaCompraDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<FacturaCompra>(dataDto);
        unitOfwork.FacturaCompras.Update(data);
        await unitOfwork.SaveAsync();
        return dataDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfwork.FacturaCompras.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfwork.FacturaCompras.Remove(data);
        await unitOfwork.SaveAsync();
        return NoContent();
    }
}