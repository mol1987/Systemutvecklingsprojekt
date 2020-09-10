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
        public int MatchId { get; set; }
        public int MatchingUserId { get; set; }
        public DateTime MatchDate { get; set; }
        public int Favorite { get; set; }
        public int Status { get; set; }
    }
}
