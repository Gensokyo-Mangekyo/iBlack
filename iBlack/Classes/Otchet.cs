using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBlack.Classes
{
   public class Otchet
    {
        public string Author { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }

        public Otchet(string author, string description, string theme)
        {
            Author = author;
            Description = description;
            Theme = theme;
        }
    }
}
