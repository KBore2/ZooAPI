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
    public class GetAllZooKeepersHandler : IRequestHandler<GetAllZooKeepersCommand, List<ZooKeeper>>
    {
        private readonly IZooKeeperRepository repository;

        public GetAllZooKeepersHandler(IZooKeeperRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ZooKeeper>> Handle(GetAllZooKeepersCommand request, CancellationToken cancellationToken)
        {
            return await repository.ListAsync(z => z.IsDeleted == false);
        }
    }
}
