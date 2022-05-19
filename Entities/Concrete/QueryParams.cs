using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class QueryParams : IDto
    {
        public string QueryString { get; set; }
        public Boolean SortType { get; set; }   // true ? sort by asc id : sort by desc id
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}
