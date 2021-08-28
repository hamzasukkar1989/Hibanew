using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hiba.Helper
{
    public interface IUploadFile
    {
        Task<string> UploadFile(IFormFile file, string Folder);
    }
    public class UploadFile : IUploadFile
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFile(IWebHostEnvironment webHostEnvironment) => _webHostEnvironment = webHostEnvironment;

        async Task<string> IUploadFile.UploadFile(IFormFile file, string Folder)
        {
            try
            {
                if (file is null)
                    return null;
                //string uploadFolder = Path.Combine("/", $"DataContent/{Folder}");
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, $"DataContent/{Folder}");
                string myPath = "";

                //string ContentRootPath = _webHostEnvironment.ContentRootPath;
                //string t = _webHostEnvironment.ContentRootFileProvider.ToString();
                uploadFolder = uploadFolder.Replace(@"\", "/");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var fileExtantion = Path.GetExtension(file.FileName);
                var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtantion}";
                myPath = $"/DataContent/{Folder}/{fileName}";
                string filePath = Path.Combine(uploadFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                filePath = filePath.Replace(_webHostEnvironment.WebRootPath, "");
                //return filePath.Replace(@"\", "/");
                return myPath;
            }
            catch
            {
                return null;
            }
        }

    }
}
