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
    public class DeleteAnimalHandler : IRequestHandler<DeleteAnimalCommand,Unit>
    {
        private readonly IAnimalRepository repository;

        public DeleteAnimalHandler(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            
            //updateAsync is used as this is a soft delete
            //hence we only update the IsDeleted field
            await repository.UpdateAsync(z => z.Id == request.Animal.Id, request.Animal);
            return Unit.Value;
        }
    }
}
