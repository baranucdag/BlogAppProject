using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
