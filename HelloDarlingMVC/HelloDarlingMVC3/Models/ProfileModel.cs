using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace HelloDarlingMVC3.Models
{
    public class ProfileModel
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(12)")] 
        public string IdentityNO { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string LastName { get; set; }


        [Column(TypeName = "varchar(100)")] public string FileName { get; set; }

        [Column(TypeName = "varchar(100)")] public string ImageName { get; set; }
        [NotMapped] 
        public IFormFile ImageFile { get; set; }


        public int? UsersCategory { get; set; }

        public DateTime JoinDate { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Place { get; set; }

        public string Gender { get; set; }

        public int? Status { get; set; }

        public string Bio { get; set; }

        public List<Match> Matches { get; set; } = new List<Match>();
        public List<Messages> UserMessages { get; set; } = new List<Messages>();

        public Appearance UserAppearance { get; set; }
        public Interests UserInterests { get; set; }
        public Preference UserPreference { get; set; }

        public IList<UserConversation> UserConversation { get; set; }
    }
}
