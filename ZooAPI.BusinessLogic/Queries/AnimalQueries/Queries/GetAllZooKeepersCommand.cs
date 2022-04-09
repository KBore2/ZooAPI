using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Queries.AnimalQueries.Queries
{
    public class GetAllAnimalsCommand : IRequest<List<Animal>>
    {
        public Animal Animal { get; set; }

        public GetAllAnimalsCommand(Animal Animal)
        {
            this.Animal = Animal;
        }
    }
}
