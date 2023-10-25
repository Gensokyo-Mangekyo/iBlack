using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBlack.Classes
{
  public class Processor : Component
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Freq { get; set; }
        public int Cores { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }
}
