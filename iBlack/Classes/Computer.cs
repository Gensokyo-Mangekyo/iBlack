using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBlack.Classes
{
   public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Motherboard Motherboard { get; set; }

        public Computer(int id, string name, Motherboard motherboard)
        {
            Id = id;
            Name = name;
            Motherboard = motherboard;
        }
    }
}
