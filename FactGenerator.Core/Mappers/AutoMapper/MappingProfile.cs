using AutoMapper;
using FactGenerator.Core.Dto;
using FactGenerator.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactGenerator.Core.Mappers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fact, FactDto>();
            CreateMap<FactDto, Fact>();
        }
    }
}
