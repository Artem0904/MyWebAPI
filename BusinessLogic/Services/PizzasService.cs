using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PizzasService : IPizzaService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Pizza> pizzasRepo;

        public PizzasService(IMapper mapper, IRepository<Pizza> pizzasRepo)
        {
            this.mapper = mapper;
            this.pizzasRepo = pizzasRepo;
        }

        public void Create(PizzaDto pizza)
        {
            pizzasRepo.Insert(mapper.Map<Pizza>(pizza));
            pizzasRepo.Save();
        }

        public void Delete(int id)
        {
            var pizza = pizzasRepo.GetByID(id);

            if (pizza == null) return; // TODO: throw exception

            pizzasRepo.Delete(pizza);
            pizzasRepo.Save();

        }

        public void Edit(PizzaDto pizza)
        {
            pizzasRepo.Update(mapper.Map<Pizza>(pizza));
            pizzasRepo.Save();

        }

        public PizzaDto? Get(int id)
        {
            var pizza = pizzasRepo.GetByID(id);
            if (pizza == null) return null;

            var dto = mapper.Map<PizzaDto>(pizza);

            return dto;
        }

        //public IEnumerable<PizzaDto> Get(IEnumerable<int> ids)
        //{
        //    return mapper.Map<List<PizzaDto>>(pizzasRepo.Get(x => ids.Contains(x.Id), includeProperties: "Category"));
        //}

        public IEnumerable<PizzaDto> GetAll()
        {
            return mapper.Map<List<PizzaDto>>(pizzasRepo.GetAll());
        }

    }
}
