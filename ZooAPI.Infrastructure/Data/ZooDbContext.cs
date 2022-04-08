using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.Models;

namespace ZooAPI.Infrastructure.Data
{
    public class ZooDbContext: DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options)
            : base(options) { }

        public DbSet<ZooKeeper> ZooKeepers { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalKeeper> AnimalKeepers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalKeeper>().HasNoKey();
        }
    }
}
