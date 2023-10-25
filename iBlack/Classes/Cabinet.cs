using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBlack.Classes
{
   public class Cabinet
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public Account account { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
