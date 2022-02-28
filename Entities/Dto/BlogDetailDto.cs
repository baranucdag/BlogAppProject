using Core.Entities.Abstract;

namespace Entities.Dto
{
    public class BlogDetailDto : IDto
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string CategoryName { get; set; }
    }
}
