using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Queries.ZooKeeperQueries.Queries
{
    public class GetAllZooKeepersCommand : IRequest<List<ZooKeeper>>
    {
        public ZooKeeper zooKeeper { get; set; }

        public GetAllZooKeepersCommand(ZooKeeper zooKeeper)
        {
            this.zooKeeper = zooKeeper;
        }
    }
}
