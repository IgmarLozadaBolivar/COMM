using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

public class CiudadController : BaseApiController
{
    private readonly IUnitOfWork unitOfwork;
    private readonly IMapper mapper;

    public CiudadController(IUnitOfWork unitOfwork, IMapper mapper)
    {
        this.unitOfwork = unitOfwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
    {
        var data = await unitOfwork.Ciudades.GetAllAsync();
        return mapper.Map<List<CiudadDto>>(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Get(int id)
    {
        var data = await unitOfwork.Ciudades.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<CiudadDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Post(CiudadDto dataDto)
    {
        var data = mapper.Map<Ciudad>(dataDto);
        unitOfwork.Ciudades.Add(data);
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
    public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<Ciudad>(dataDto);
        unitOfwork.Ciudades.Update(data);
        await unitOfwork.SaveAsync();
        return dataDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfwork.Ciudades.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfwork.Ciudades.Remove(data);
        await unitOfwork.SaveAsync();
        return NoContent();
    }
}