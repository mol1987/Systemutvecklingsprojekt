using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC.Models
{
    public class Match
    {
        [Key, Column(Order = 0)]
        public int UserMatchingId { get; set; }
        [Key, Column(Order = 1)]
        public int UserMatcheeId { get; set; }
        public DateTime MatchDate { get; set; }
        public int Favorite { get; set; }
        public int Status { get; set; }
    }
}
