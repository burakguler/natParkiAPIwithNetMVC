using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiWEB.Models
{
    public class NationalPark

    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Area { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ListingDate { get; set; }

    }
}
