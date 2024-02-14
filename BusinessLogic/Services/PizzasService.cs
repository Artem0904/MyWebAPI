using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
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
        private readonly PizzeriaDbContext context;

        public PizzasService(IMapper mapper, PizzeriaDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void Create(PizzaDto pizza)
        {
            context.Pizzas.Add(mapper.Map<Pizza>(pizza));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pizza = context.Pizzas.Find(id);

            if (pizza == null) return; // TODO: throw exception

            context.Remove(pizza);
            context.SaveChanges();
        }

        public void Edit(PizzaDto pizza)
        {
            context.Pizzas.Update(mapper.Map<Pizza>(pizza));
            context.SaveChanges();
        }

        public PizzaDto? Get(int id)
        {
            var item = context.Pizzas.Find(id);
            if (item == null) return null;

            var dto = mapper.Map<PizzaDto>(item);

            return dto;
        }

        public IEnumerable<PizzaDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<PizzaDto>>(context.Pizzas.ToList());
        }

        public IEnumerable<PizzaDto> GetAll()
        {
            return mapper.Map<List<PizzaDto>>(context.Pizzas.ToList());
        }

    }
}
