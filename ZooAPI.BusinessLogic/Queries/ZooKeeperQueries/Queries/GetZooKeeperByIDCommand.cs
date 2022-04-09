using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Queries.ZooKeeperQueries.Queries
{
    public class GetZooKeeperByIDCommand : IRequest<ZooKeeper>
    {
        public ZooKeeper zooKeeper { get; set; }

        public GetZooKeeperByIDCommand(ZooKeeper zooKeeper)
        {
            this.zooKeeper = zooKeeper;
        }
    }
}
