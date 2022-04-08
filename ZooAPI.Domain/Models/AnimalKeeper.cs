using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAPI.Domain.Models
{
    public class AnimalKeeper
    {
        public AnimalKeeper()
        {
            ZooKeepers = new List<ZooKeeper>();
            Animals = new List<Animal>();
        }
        public int ZooKeeperID { get; set; }

        public int AnimalID { get; set; }
        public virtual ICollection<ZooKeeper> ZooKeepers { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
