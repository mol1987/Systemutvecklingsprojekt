﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC.Models
{
    public class Messages
    {
        public int MessagesId { get; set; }
       
       
        [Required]
        public int UserId { get; set; }

        public DateTime JoinDate { get; set; }

        [Required]
        public int MessageStatus { get; set; }

    }
}
