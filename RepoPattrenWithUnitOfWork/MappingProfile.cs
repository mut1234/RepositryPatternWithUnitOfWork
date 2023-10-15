using AutoMapper;
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
            CreateMap<book, BookDto>()//s = source ,d = destination
                .ReverseMap();

            CreateMap<Author, DtoAuthor>()//.ForMember(d => d.Id, s => s.MapFrom(s => s.Id))//s = source ,d = destination
            .ReverseMap();
        }
    }

}
