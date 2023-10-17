using AutoMapper;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Book, BookDto>()//s = source ,d = destination
                .ReverseMap();

            CreateMap<Author, AuthorDto>()//.ForMember(d => d.Id, s => s.MapFrom(s => s.Id))//s = source ,d = destination
            .ReverseMap();

            CreateMap<AddAuthorCommand, Author > ();
            CreateMap<DeleteAuthorCommand, Author > ();
            CreateMap<UpdateAuthorCommand, Author > ();
            CreateMap<Author, FindAuthorResponseDto>();
            CreateMap<Author, FindAllAuthorResponseDto>();
            CreateMap<Author, GetByIdAuthorResponseDto>();
            CreateMap<Author, GetAllAuthorResponseDto>();

            CreateMap<Book, GetByIdBookResponseDto>();
            CreateMap<Book, GetAllBookResponseDto>();
            CreateMap<Book, GetByNameResponseDto>();
            CreateMap<UpdateBookCommand, Book>();




        }
    }

}
