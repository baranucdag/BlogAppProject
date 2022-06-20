using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        // Delete - delete an ımage by ımagePath 
        public void Delete(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        // Upload - Upload an ımage by file and root
        public string Upload(IFormFile file, string root)
        {

            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string filePath = guid + extension;


                    using (FileStream fileStream = File.Create(root + filePath))
                    {

                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return filePath;
                    }
            }
            return "file is empty";
        }
    }
}

