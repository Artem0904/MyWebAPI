using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<PizzaDto> GetAll();
        IEnumerable<PizzaDto> Get(IEnumerable<int> ids);
        PizzaDto? Get(int id);
        void Create(PizzaDto product);
        void Edit(PizzaDto product);
        void Delete(int id);
    }
}
