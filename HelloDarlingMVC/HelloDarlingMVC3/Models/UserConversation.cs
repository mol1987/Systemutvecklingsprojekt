using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC3.Models
{
    public class UserConversation
    {
        [Key]
        public string ProfileModelId { get; set; }
        public ProfileModel ProfileModel { get; set; }

        [Key]
        public int ConversationsId { get; set; }
        public Conversations Conversations { get; set; }
    }
}
