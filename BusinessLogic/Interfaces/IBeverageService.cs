using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IBeverageService
    {
        IEnumerable<BeverageDto> GetAll();
        BeverageDto? Get(int id);
        void Create(BeverageDto pizza);
        void Edit(BeverageDto pizza);
        void Delete(int id);
    }
}
