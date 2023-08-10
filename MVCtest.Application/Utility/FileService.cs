using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Application.Utility
{
    public class FileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment Environment)
        {
            _environment = Environment;
        }

        public async Task<string> StoreFileAsync(IFormFile file, string localPath)
        {
            string path;
            if (file.Length > 0)
            {
                //TODO: each file directory path should be set via a global variable.
                path = Path.GetFullPath(Path.Combine(this._environment.WebRootPath, localPath));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fName = Guid.NewGuid().ToString() + "_" + file.FileName;
                using (var fileStream = new FileStream(Path.Combine(path,fName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return fName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
