using FactGenerator.Repo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactGenerator.Repo.Models
{
    public class Fact : IEntity
    {
        public int Id { get; set; }
        public string? Details { get; set; }
    }
}
