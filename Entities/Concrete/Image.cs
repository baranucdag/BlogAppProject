using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
