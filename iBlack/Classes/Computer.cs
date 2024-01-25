using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBlack.Classes
{
   public class Computer
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Motherboard Motherboard { get; set; }
        public Videocard Videocard { get; set; }
        public HardDisk HardDisk { get; set; }
        public UnitPower UnitPower { get; set; }
        public RAM RAM { get; set; }
        public Processor Processor { get; set; }
        public Cabinet Cabinet { get; set; }

        public Computer(int? id, string name, Motherboard motherboard, Videocard videocard, HardDisk hardDisk, UnitPower unitPower, RAM rAM, Processor processor, Cabinet cabinet)
        {
            Id = id;
            Name = name;
            Motherboard = motherboard;
            Videocard = videocard;
            HardDisk = hardDisk;
            UnitPower = unitPower;
            RAM = rAM;
            Processor = processor;
            this.Cabinet = cabinet;
        }

        //public Computer(int id, string name, Motherboard motherboard)
        //{
        //    Id = id;
        //    Name = name;
        //    Motherboard = motherboard;
        //}
    }
}
