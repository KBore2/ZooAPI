using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.BusinessLogic.Commands.AnimalCommands.Commands
{
    public class AddAnimalCommand : IRequest<Animal>
    {
        public Animal Animal { get; set; }

        public AddAnimalCommand(Animal Animal)
        {
            this.Animal = Animal;
        }
    }
}
