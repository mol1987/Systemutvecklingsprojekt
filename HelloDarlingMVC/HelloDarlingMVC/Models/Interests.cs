﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDarlingMVC.Models
{
    public class Interests
    {
        [Key]
        public int UserId { get; set; }
        public User user { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Sports { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string Music { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string Movies { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string Books { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string Language { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string TVgame { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string Cars { get; set; }
    }
}
