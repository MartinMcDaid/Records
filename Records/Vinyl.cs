using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Records
{
    public class Vinyl
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public string Artist { get; set; } 
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
