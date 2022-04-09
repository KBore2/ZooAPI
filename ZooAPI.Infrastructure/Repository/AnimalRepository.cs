using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.IRepository;
using ZooAPI.Infrastructure.Data;
using MediatR;
using ZooAPI.Domain.Models;

namespace ZooAPI.Infrastructure.Repository
{
    public class AnimalRepository : BaseRepository<Animal> , IAnimalRepository
    { 
        

        public AnimalRepository(ZooDbContext dbContext) : base(dbContext)
        {
   
        }
        
    }
}
