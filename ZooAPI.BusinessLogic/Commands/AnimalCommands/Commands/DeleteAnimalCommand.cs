using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Commands.AnimalCommands.Commands
{
    public class DeleteAnimalCommand : IRequest<Unit>
    {
        public Animal Animal { get; set; }

        public DeleteAnimalCommand(Animal Animal)
        {
            this.Animal = Animal;

        }
    }
}
