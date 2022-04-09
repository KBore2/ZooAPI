using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.BusinessLogic.Queries.ZooKeeperQueries.Queries;
using ZooAPI.Domain.IRepository;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Queries.ZooKeeperQueries.Handlers
{
    public class GetZooKeeperByIDHandler : IRequestHandler<GetZooKeeperByIDCommand,ZooKeeper>
    {
        private readonly IZooKeeperRepository repository;

        public GetZooKeeperByIDHandler(IZooKeeperRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ZooKeeper> Handle(GetZooKeeperByIDCommand request, CancellationToken cancellationToken)
        {
           return await repository.GetAsync(z => z.Id == request.zooKeeper.Id);
        }
    }
}
