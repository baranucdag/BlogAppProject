using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog Get();
        void Add(Blog blog);    
        void Update(Blog blog);
        void Delete(Blog blog);
        
    }
}
