using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork unitOfwork;
    private readonly IMapper mapper;

    public CategoriaController(IUnitOfWork unitOfwork, IMapper mapper)
    {
        this.unitOfwork = unitOfwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
    {
        var data = await unitOfwork.Categorias.GetAllAsync();
        return mapper.Map<List<CategoriaDto>>(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Get(int id)
    {
        var data = await unitOfwork.Categorias.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<CategoriaDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Post(CategoriaDto dataDto)
    {
        var data = mapper.Map<Categoria>(dataDto);
        unitOfwork.Categorias.Add(data);
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
    public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody] CategoriaDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Categoria>(dataDto);
        unitOfwork.Categorias.Update(data);
        await unitOfwork.SaveAsync();
        return dataDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfwork.Categorias.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfwork.Categorias.Remove(data);
        await unitOfwork.SaveAsync();
        return NoContent();
    }
}