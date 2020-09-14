using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC.Models
{
    public class Preference
    {
        [Key]
        public int UserId { get; set; }
        public User user { get; set; }
        public int PreferenceId { get; set; }
        public int Age { get; set; }
    }
}
