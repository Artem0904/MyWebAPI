using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<PizzaDto> GetAll();
        //IEnumerable<PizzaDto> Get(IEnumerable<int> ids);
        PizzaDto? Get(int id);
        void Create(CreatePizzaModel pizza);
        void Edit(PizzaDto pizza);
        void Delete(int id);
    }
}
