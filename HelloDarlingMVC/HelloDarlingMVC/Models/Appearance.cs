using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC.Models
{
    public class Appearance
    {
        [Key]
        public int UserId { get; set; }
        public User user { get; set; }


        [Column(TypeName = "varchar(32)")]
        public string HairColor { get; set; }
        public int Height { get; set; }
    }
}

