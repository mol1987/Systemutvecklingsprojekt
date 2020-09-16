using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Models
{
    public class Preference
    {
        [Key]
        public Guid ProfileModelId { get; set; }
        public ProfileModel ProfileModel { get; set; }

        public int Age { get; set; }
    }
}
