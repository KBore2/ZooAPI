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
    public class AddZooKeeperHandler : IRequestHandler<AddZooKeeperCommand,ZooKeeper>
    {
        private readonly IZooKeeperRepository repository;

        public AddZooKeeperHandler(IZooKeeperRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ZooKeeper> Handle(AddZooKeeperCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.ZooKeeper);
        }
    }
}
