using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BlogDetail : IDto
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string  BlogContent { get; set; }
        public string CategoryName { get; set; }
    }
}
