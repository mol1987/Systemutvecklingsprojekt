using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HelloDarlingMVC3.Models
{
    public class Match
    {
        [Key]
        public string Profile1Id { get; set; }
        public ProfileModel Profile1 { get; set; }

        [Key]
        public string Profile2Id { get; set; }
        public ProfileModel Profile2 { get; set; }

        public DateTime MatchDate { get; set; }

        public int Favorite { get; set; }
        public int Status { get; set; }
    }
}
