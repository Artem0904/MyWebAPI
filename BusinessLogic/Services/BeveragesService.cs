using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
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
            var beverage = beveragesRepo.GetByID(id);

            if (beverage == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            beveragesRepo.Delete(beverage);
            beveragesRepo.Save();

        }

        public void Edit(BeverageDto beverage)
        {
            beveragesRepo.Update(mapper.Map<Beverage>(beverage));
            beveragesRepo.Save();

        }

        public BeverageDto? Get(int id)
        {
            var beverage = beveragesRepo.GetByID(id);
            if (id < 0) throw new HttpException("Id must be positive:)", HttpStatusCode.BadRequest);
            if (beverage == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            var dto = mapper.Map<BeverageDto>(beverage);

            return dto;
        }

        public IEnumerable<BeverageDto> GetAll()
        {
            return mapper.Map<List<BeverageDto>>(beveragesRepo.GetAll());
        }

    }
}
