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
        public DisplayItem(string name, string fitness)
        {
            this.name = name;
            this.fitness = fitness;
        }
        public DisplayItem() {
            
        }


    }
}
