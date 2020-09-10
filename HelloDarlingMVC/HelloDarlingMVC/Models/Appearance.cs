using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC.Models
{
    public class Appearance
    {
        public int AppearanceId { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string HairColor { get; set; }
        public int Height { get; set; }
        
    }
}

