using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Models
{
    public class RoomCheckedIn
    {
        [Key]
        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }

        public DateTime Date { get; set; }
    }
}
