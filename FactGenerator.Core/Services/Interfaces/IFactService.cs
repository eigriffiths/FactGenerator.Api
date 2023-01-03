using FactGenerator.Core.Dto;

namespace FactGenerator.Core.Services.Interfaces
{
    public interface IFactService
    {
        IEnumerable<FactDto> GetAllFacts();
        FactDto GetFact(int id);
        bool CreateFact(FactDto factDto);
        void EditFact(FactDto factDto);
        void DeleteFact(int id);
    }
}