    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Models
{
    public class Conversations
    {
        public Guid ConversationsId { get; set; }

        public Guid MessagesId { get; set; }

        public List<Messages> Messages { get; set; }

        public IList<ConversationsMessages> ConversationsMessages { get; set; }

        public IList<UserConversation> UserConversation { get; set; }
    }
}
