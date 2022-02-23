﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public int LikedAmount { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}