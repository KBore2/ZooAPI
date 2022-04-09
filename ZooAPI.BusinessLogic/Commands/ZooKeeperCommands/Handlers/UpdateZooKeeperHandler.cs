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
    public class UpdateZooKeeperHandler : IRequestHandler<UpdateZooKeeperCommand,ZooKeeper>
    {
        private readonly IZooKeeperRepository repository;

        public UpdateZooKeeperHandler(IZooKeeperRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ZooKeeper> Handle(UpdateZooKeeperCommand request, CancellationToken cancellationToken)
        {
            
            var response = await repository.UpdateAsync(z => z.Id == request.ZooKeeper.Id, request.ZooKeeper);
            return response;
        }
    }
}
