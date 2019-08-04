using System;
using System.Collections.Generic;

namespace forumTest.Models
{
    public class CommentsViewModel
    {
        public Guid ParentId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}