using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League
{
    public class Legends
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public Group Group { get; set; }
        public Parent Parents { get; set; }
        public Bond Bonds { get; set; }
    }
}
