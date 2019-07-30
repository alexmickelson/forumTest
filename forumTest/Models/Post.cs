using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace forumTest.Models
{
    public class Post
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        public string User { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}
