using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<PizzaDto, Pizza>()
                .ForMember(x => x.PizzasSize, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CreatePizzaModel, Pizza>()
                .ReverseMap();

            CreateMap<RegisterModel, Client>()
                .ForMember(x => x.UserName, opts => opts.MapFrom(s => s.Email));
        }
    }
}
