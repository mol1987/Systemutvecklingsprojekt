using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Models
{
    public class Appearance
    {
        [Key]
        public Guid ProfileModelId { get; set; }
        public ProfileModel ProfileModel { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string HairColor { get; set; }
    }
}
