using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Commands.ZooKeeperCommands.Commands
{
    public class UpdateZooKeeperCommand : IRequest<ZooKeeper>
    {
        public ZooKeeper ZooKeeper { get; set; }

        public UpdateZooKeeperCommand(ZooKeeper zooKeeper)
        {
            this.ZooKeeper = zooKeeper;
        }
    }
}
