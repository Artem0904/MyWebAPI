using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IBeverageService
    {
        IEnumerable<BeverageDto> GetAll();
        Task<BeverageDto?> Get(int id);
        void Create(BeverageCreateModel pizza);
        void Edit(BeverageDto pizza);
        void Delete(int id);
    }
}
