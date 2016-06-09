using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przepisy
{
    class DisplayItem
    {
        public string name { get; set; }
        public string fitness { get; set; }
        public int id { get; set; } 
        public DisplayItem(string name, string fitness, int id)
        {
            this.name = name;
            this.fitness = fitness;
            this.id = id;
        }
        public DisplayItem() {
            
        }


    }
}
