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

