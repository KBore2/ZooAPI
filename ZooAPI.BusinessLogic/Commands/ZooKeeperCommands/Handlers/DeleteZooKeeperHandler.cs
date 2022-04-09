using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.BusinessLogic.Commands.ZooKeeperCommands.Commands;
using ZooAPI.Domain.IRepository;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Commands.ZooKeeperCommands.Handlers
{
    public class DeleteZooKeeperHandler : IRequestHandler<DeleteZooKeeperCommand,Unit>
    {
        private readonly IZooKeeperRepository repository;

        public DeleteZooKeeperHandler(IZooKeeperRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteZooKeeperCommand request, CancellationToken cancellationToken)
        {
            await repository.UpdateAsync(z => z.Id == request.ZooKeeper.Id, request.ZooKeeper);
            return Unit.Value;
        }
    }
}
