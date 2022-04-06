using AutoMapper;
using myApp.entitiy.LibraryEntities;
using myApp.webuı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.webuı.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookModel>().ReverseMap();

            CreateMap<Author, AuthorModel>()
                .ForMember(dest => dest.FirstName, opt =>
                   {
                       opt.MapFrom(src => src.FirstName);
                   });
        }
    }
}
