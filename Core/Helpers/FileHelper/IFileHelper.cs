using Core.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root);
        void Delete(string filePath);
    }
}
