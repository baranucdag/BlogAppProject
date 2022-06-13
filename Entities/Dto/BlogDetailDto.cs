using Core.Entities.Abstract;
using System;

namespace Entities.Dto
{
    public class BlogDetailDto : IDto
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
