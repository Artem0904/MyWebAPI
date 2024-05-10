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
                .ForMember(x => x.PizzaSize, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CreatePizzaModel, Pizza>()
                .ReverseMap();

            CreateMap<PizzaSizeDto, PizzaSize>()
                .ReverseMap();

            CreateMap<RegisterModel, User>()
                .ForMember(x => x.UserName, opts => opts.MapFrom(s => s.Email));

            CreateMap<BeverageDto, Beverage>()
               .ReverseMap();
        }
    }
}
