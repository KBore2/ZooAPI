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
    public class UpdateAnimalHandler : IRequestHandler<UpdateAnimalCommand,Animal>
    {
        private readonly IAnimalRepository repository;

        public UpdateAnimalHandler(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Animal> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            
            //updateAsync is used as this is a soft Update
            //hence we only update the IsUpdated field
            var response = await repository.UpdateAsync(z => z.Id == request.Animal.Id, request.Animal);
            return response;
        }
    }
}
