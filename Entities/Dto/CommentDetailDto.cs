using Core.Entities.Abstract;
using System;

namespace Entities.Dto
{
    public class CommentDetailDto:IDto
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
