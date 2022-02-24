using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BlogTagDetail : IDto
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public string BlogTitle { get; set; }
        public string TagName { get; set; }
    }
}
