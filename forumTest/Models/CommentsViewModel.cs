using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forumTest.Models
{
    public class CommentsViewModel
    {
        public List<Comment> Comments { get; set; }

        public Guid? parent { get; set; }

    }
}
