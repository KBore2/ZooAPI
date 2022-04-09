using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.BusinessLogic.Queries.AnimalQueries.Queries;
using ZooAPI.Domain.IRepository;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Queries.AnimalQueries.Handlers
{
    public class GetAnimalByIDHandler : IRequestHandler<GetAnimalByIDCommand,Animal>
    {
        private readonly IAnimalRepository repository;

        public GetAnimalByIDHandler(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Animal> Handle(GetAnimalByIDCommand request, CancellationToken cancellationToken)
        {
           return await repository.GetAsync(z => z.Id == request.Animal.Id);
        }
    }
}
