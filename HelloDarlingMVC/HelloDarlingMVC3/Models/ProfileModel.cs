using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HelloDarlingMVC3.Models
{
    public class ProfileModel
    {
        [Key]
        public string Id { get; set; }
        public IdentityUser IdentityUser { get; set; }


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
        public int UsersCategory { get; set; }

        public DateTime JoinDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Place { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public int Status { get; set; }

        public List<Match> Matches { get; set; } = new List<Match>();
        public List<Messages> UserMessages { get; set; } = new List<Messages>();

        public Appearance UserAppearance { get; set; }
        public Interests UserInterests { get; set; }
        public Preference UserPreference { get; set; }

        public IList<UserConversation> UserConversation { get; set; }
    }
}
