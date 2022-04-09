using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.BusinessLogic.Commands.AnimalCommands.Commands;
using ZooAPI.Domain.IRepository;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Commands.AnimalCommands.Handlers
{
    public class AddAnimalHandler : IRequestHandler<AddAnimalCommand,Animal>
    {
        private readonly IAnimalRepository repository;

        public AddAnimalHandler(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Animal> Handle(AddAnimalCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.Animal);
        }
    }
}
