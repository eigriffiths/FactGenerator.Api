using FactGenerator.Core.Dto;

namespace FactGenerator.Core.Services.Interfaces
{
    public interface IFactService
    {
        IEnumerable<FactDto> GetAllFacts();
    }
}