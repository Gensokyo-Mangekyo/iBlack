using iBlack.Enums;
using System.Collections.Generic;

namespace iBlack.Classes
{
   public class Motherboard : Component
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public List<Port> Ports { get; set; }
        public int RamSlots { get; set; }
        public FormFactor FormFactor { get; set; }
        public string Socket { get; set; }
        public int SATAslots { get; set; }
        public int Pcislots { get; set; }


        public Motherboard()
        {

        }

        public Motherboard(string Model)
        {
            this.Model = Model;
        }

        public override string ToString()
        {
            return Model;
        }
    }
}
