using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork unitOfwork;
    private readonly IMapper mapper;

    public DepartamentoController(IUnitOfWork unitOfwork, IMapper mapper)
    {
        this.unitOfwork = unitOfwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
    {
        var data = await unitOfwork.Departamentos.GetAllAsync();
        return mapper.Map<List<DepartamentoDto>>(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Get(int id)
    {
        var data = await unitOfwork.Departamentos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<DepartamentoDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Post(DepartamentoDto dataDto)
    {
        var data = mapper.Map<Departamento>(dataDto);
        unitOfwork.Departamentos.Add(data);
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
    public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<Departamento>(dataDto);
        unitOfwork.Departamentos.Update(data);
        await unitOfwork.SaveAsync();
        return dataDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfwork.Departamentos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfwork.Departamentos.Remove(data);
        await unitOfwork.SaveAsync();
        return NoContent();
    }
}