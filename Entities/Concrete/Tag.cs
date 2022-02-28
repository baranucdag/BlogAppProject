﻿using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
    }
}
