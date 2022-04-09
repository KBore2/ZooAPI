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
    public class GetAllAnimalsHandler : IRequestHandler<GetAllAnimalsCommand, List<Animal>>
    {
        private readonly IAnimalRepository repository;

        public GetAllAnimalsHandler(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Animal>> Handle(GetAllAnimalsCommand request, CancellationToken cancellationToken)
        {
            return await repository.ListAsync(z => z.IsDeleted == false);
        }
    }
}
