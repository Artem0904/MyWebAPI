using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Services
{
    public class PizzasService : IPizzaService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Pizza> pizzasRepo;
        private readonly IRepository<PizzaSize> pizzaSizeRepo;

        public PizzasService(IMapper mapper, IRepository<Pizza> pizzasRepo, IRepository<PizzaSize> pizzaSizeRepo)
        {
            this.mapper = mapper;
            this.pizzasRepo = pizzasRepo;
            this.pizzaSizeRepo = pizzaSizeRepo;
        }

        public void Create(CreatePizzaModel pizza)
        {
            pizzasRepo.Insert(mapper.Map<Pizza>(pizza));
            pizzasRepo.Save();
        }

        public void Delete(int id)
        {
            var pizza = pizzasRepo.GetById(id);

            if (pizza == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            pizzasRepo.Delete(pizza);
            pizzasRepo.Save();

        }

        public void Edit(PizzaDto pizza)
        {
            pizzasRepo.Update(mapper.Map<Pizza>(pizza));
            pizzasRepo.Save();

        }

        public async Task<PizzaDto?> Get(int id)
        {
            if (id < 0) throw new HttpException("Id must be positive:)", HttpStatusCode.BadRequest);
            var pizza = await pizzasRepo.GetItemBySpec(new PizzaSpecs.ById(id));
            if (pizza == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            var dto = mapper.Map<PizzaDto>(pizza);

            return dto;
        }

        //public IEnumerable<PizzaDto> Get(IEnumerable<int> ids)
        //{
        //    return mapper.Map<List<PizzaDto>>(pizzasRepo.Get(x => ids.Contains(x.Id), includeProperties: "PizzaSize"));
        //}

        public async Task<IEnumerable<PizzaDto>> GetAll()
        {
            return mapper.Map<List<PizzaDto>>(await pizzasRepo.GetListBySpec(new PizzaSpecs.All())); 
        }

        public IEnumerable<PizzaSizeDto> GetAllPizzaSizes()
        {
            return mapper.Map<List<PizzaSizeDto>>(pizzaSizeRepo.GetAll());
        }
    }
}
