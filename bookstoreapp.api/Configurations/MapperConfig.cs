using AutoMapper;
using bookstoreapp.api.Data;
using bookstoreapp.api.Models.Author;

namespace bookstoreapp.api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // Author Data Transfer Object //
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
        }

    }
}
