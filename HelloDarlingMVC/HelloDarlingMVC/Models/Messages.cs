using System;
using System.ComponentModel.DataAnnotations;

namespace HelloDarlingMVC.Models
{
    public class Messages
    {
        public int MessagesId { get; set; }
        public User user { get; set; }


        [Required]
        public int UserId { get; set; }

        public DateTime JoinDate { get; set; }

        [Required]
        public int MessageStatus { get; set; }

    }
}
