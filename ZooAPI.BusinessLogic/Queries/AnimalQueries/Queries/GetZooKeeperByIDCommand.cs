using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Queries.AnimalQueries.Queries
{
    public class GetAnimalByIDCommand : IRequest<Animal>
    {
        public Animal Animal { get; set; }

        public GetAnimalByIDCommand(Animal Animal)
        {
            this.Animal = Animal;
        }
    }
}
