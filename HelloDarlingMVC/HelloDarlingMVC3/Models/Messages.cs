﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Models
{
    public class Messages
    {
        [Key]
        public Guid MessageID { get; set; }

        [ForeignKey("ProfileModelID")]
        public Guid SenderId { get; set; }

        ProfileModel Sender { get; set; }

        public DateTime MessageDate { get; set; }

        public int MessageStatus { get; set; }

        public IList<ConversationsMessages> ConversationsMessages { get; set; }

     

    }
}
