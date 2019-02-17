using Microsoft.AspNetCore.Http;
using System;

namespace DtoModels.EntityDtoModels
{
    public class FileDto
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public IFormFile File { get; set; }
    }
}
