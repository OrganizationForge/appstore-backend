using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductComments.Queries
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Content { get; set; }
        public string? CustomerImage { get; set; }
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public int Rating { get; set; }
        public int Likes { get; set; } 
        public int Dislikes { get; set; }
        public DateTime Created { get; set; }
    }
}
