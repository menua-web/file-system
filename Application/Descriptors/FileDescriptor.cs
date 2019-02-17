using Application.Enums;
using Domain.Entities;
using DtoModels.EntityDtoModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace Application.Descriptors
{
    public class FileDescriptor
    {
        private string _name;
        private FileDto _fileDto;
        private IHostingEnvironment _env;
        public FileDescriptor(FileDto fileDto, IHostingEnvironment env)
        {
            _name = Guid.NewGuid().ToString();
            _fileDto = fileDto;
            _env = env;
        }

        public string Path => System.IO.Path.Combine(_env.WebRootPath, RootFolder.Files.ToString());
        public string Name => _name;
        public string Extension => System.IO.Path.GetExtension(_fileDto.File.FileName);

        public async Task Override(File file)
        {
            using (var fileStream = new System.IO.FileStream(file.ToString(), System.IO.FileMode.Create))
            {
                await _fileDto.File.CopyToAsync(fileStream);
            }
        }
    }
}
