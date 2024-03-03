using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
namespace Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<TipoPago, TipoPagoDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Producto, ProductoDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<FacturaVenta, FacturaVentaDto>().ReverseMap();
        CreateMap<FacturaCompra, FacturaCompraDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
    }
}