using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Services
{
    public class FileService
    {
        public const int maxFileSize = 10485760;
        public IWebHostEnvironment _env { get; }
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<List<string>> SaveFiles(IReadOnlyList<IBrowserFile> files)
        {
            var list = new List<string>();
            var guid = Guid.NewGuid().ToString();
            foreach (var file in files)
            {
                var url = await SaveFile(file, guid);
                list.Add(url);
            }
            return list;
        }

        public async Task<string> SaveFile(IBrowserFile file, string guid = null)
        {
            if (guid == null)
            {
                guid = Guid.NewGuid().ToString();
            }
            var relativePath = Path.Combine("uploads", guid);
            var dirToSave = Path.Combine(_env.WebRootPath, relativePath);
            var di = new DirectoryInfo(dirToSave);
            if (!di.Exists)
            {
                di.Create();
            }
            var filePath = Path.Combine(dirToSave, file.Name);
            using (var stream = file.OpenReadStream(maxFileSize))
            {
                using (var mstream = new MemoryStream())
                {
                    await stream.CopyToAsync(mstream);
                    await File.WriteAllBytesAsync(filePath, mstream.ToArray());
                }
            }
            var url = Path.Combine(relativePath, file.Name).Replace("\\", "/");
            return url;
        }
    }
}
