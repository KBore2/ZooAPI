using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZooAPI.Domain.IRepository
{
    public interface IAnimalKeeperRepository<TEntity> where TEntity : class
    {

    }
}
