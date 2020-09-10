using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(12)")]
        public string IdentityNO { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Required]
        [MaxLength(5)]
        public int UsersCategory { get; set; }
        public DateTime JoinDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Place { get; set; }
        //public Blog Photo { get; set; }
        [Required]
        [MaxLength(3)]
        public int Gender { get; set; }
        [Required]
        [MaxLength(3)]
        public int Status { get; set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Password { get; set; }

        public List<Match> Matches { get; set; } = new List<Match>();
        public List<Messages> UserMessages { get; set; } = new List<Messages>();
        public Appearance UserAppearance { get; set; }
        public Interests UserInterests { get; set; }
        public Preference UserPreference { get; set; }

    }
}
