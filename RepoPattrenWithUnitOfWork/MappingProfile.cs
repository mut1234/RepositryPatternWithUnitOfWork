using AutoMapper;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands;
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
        }
    }

}
