using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using System.Net;

namespace BusinessLogic.Services
{
    public class BeveragesService : IBeverageService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Beverage> beveragesRepo;

        public BeveragesService(IMapper mapper, IRepository<Beverage> beveragesRepo)
        {
            this.mapper = mapper;
            this.beveragesRepo = beveragesRepo;
        }

        public void Create(BeverageDto beverage)
        {
            beveragesRepo.Insert(mapper.Map<Beverage>(beverage));
            beveragesRepo.Save();
        }

        public void Delete(int id)
        {
            var beverage = beveragesRepo.GetById(id);

            if (beverage == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            beveragesRepo.Delete(beverage);
            beveragesRepo.Save();

        }

        public void Edit(BeverageDto beverage)
        {
            beveragesRepo.Update(mapper.Map<Beverage>(beverage));
            beveragesRepo.Save();

        }

        public async Task<BeverageDto?> Get(int id)
        {
            if (id < 0) throw new HttpException("Id must be positive:)", HttpStatusCode.BadRequest);
            var pizza = await beveragesRepo.GetItemBySpec(new BeverageSpecs.ById(id));
            if (pizza == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            var dto = mapper.Map<BeverageDto>(pizza);

            return dto;
        }

        public  IEnumerable<BeverageDto> GetAll()
        {
            return mapper.Map<List<BeverageDto>>(beveragesRepo.GetAll());
        }

    }
}
