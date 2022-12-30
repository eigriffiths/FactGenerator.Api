using AutoMapper;
using FactGenerator.Core.Dto;
using FactGenerator.Core.Services.Interfaces;
using FactGenerator.Repo.DAL;
using FactGenerator.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FactGenerator.Core.Services
{
    public class FactService : GenericRepository<Fact>, IFactService
    {
        private readonly IMapper _mapper;

        public FactService(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public IEnumerable<FactDto> GetAllFacts()
        {
            var facts = All();

            var mapped = _mapper.Map<IEnumerable<FactDto>>(facts);

            return mapped;
        }

        public FactDto GetFact(int id)
        {
            var fact = All().Where(e => e.Id == id).FirstOrDefault();

            var mapped = _mapper.Map<FactDto>(fact);

            return mapped;
        }

        public bool CreateFact(FactDto factDto)
        {
            var fact = _mapper.Map<Fact>(factDto);

            Add(fact);

            return true;
        }

        public void EditFact(FactDto factDto)
        {
            var fact = _mapper.Map<Fact>(factDto);

            Update(fact);
        }

        public void DeleteFact(int id)
        {
            var fact = Get(id);

            Delete(fact);
        }
    }
}
