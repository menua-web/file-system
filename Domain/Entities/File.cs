using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class File : EntityBase<Int64>
    {
        public File()
        {
        }

        public File(string path, string name, string extension)
        {
            Path = path; FileName = name; Extension = extension;
        }

        public string FileName { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }

        public override string ToString()
        {
            return System.IO.Path.Combine(Path, FileName + Extension);
        }
    }
}
