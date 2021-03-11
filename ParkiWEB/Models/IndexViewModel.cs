using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiWEB.Models
{
    public class IndexViewModel
    {
        public IEnumerable<NationalPark> NationalParkList { get; set; }
        public IEnumerable<Trail> TrailList { get; set; }

        public IEnumerable<Trail> Trails { get; set; }
    }
}
