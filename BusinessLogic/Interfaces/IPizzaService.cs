using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDto>> GetAll();
        //Task<IEnumerable<PizzaDto>> Get(IEnumerable<int> ids);
        Task<PizzaDto?> Get(int id);
        void Create(CreatePizzaModel pizza);
        void Edit(PizzaDto pizza);
        void Delete(int id);
        IEnumerable<PizzaSizeDto> GetAllPizzaSizes();
    }
}
