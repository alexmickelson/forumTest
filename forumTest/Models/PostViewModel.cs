using System;
using System.Collections.Generic;

namespace forumTest.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }

    }
}