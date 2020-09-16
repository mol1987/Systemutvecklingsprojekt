using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Models
{
    public class ConversationsMessages
    {
        [Key]
        public Guid ConversationsId { get; set; }
        public Conversations Conversations { get; set; }

        [Key]
        public Guid MessageID { get; set; }
        public Messages Messages { get; set; }
    }
}
