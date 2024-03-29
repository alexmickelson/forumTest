﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace forumTest.Models
{
    public class Comment
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid Post { get; set; }
        public Guid Parent { get; set; }
    }
}
