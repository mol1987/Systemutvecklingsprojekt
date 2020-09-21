using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Models
{
    public class Preference
    {
        [Key]
        public Guid ProfileModelId { get; set; }
        public ProfileModel ProfileModel { get; set; }

        public string Age { get; set; }

        public int? PreferredGender { get; set; }
    }
}
