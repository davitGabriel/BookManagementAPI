using AutoMapper;
using BookManagementAPI.Models;
using BookManagementAPI.Models.DTO;

namespace BookManagementAPI.MappingProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<AddBookDTO, Book>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
