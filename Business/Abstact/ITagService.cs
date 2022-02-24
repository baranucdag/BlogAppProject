using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ITagService
    {
        List<Tag> GetAll();
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}
