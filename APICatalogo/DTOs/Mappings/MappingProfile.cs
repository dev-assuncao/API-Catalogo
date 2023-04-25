using APICatalogo.Models;
using AutoMapper;

namespace APICatalogo.DTOs.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
        }
    }
}
