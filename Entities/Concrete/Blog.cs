using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
