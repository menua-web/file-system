using Domain.Entities;
using System;

namespace Domain.Extensions
{
    public static class FileExtension
    {
        public static string GetFullPath(this File file)
        {
            if (file == null) throw new ArgumentNullException();
            return System.IO.Path.Combine(file.Path, file.FileName + file.Extension);
        }
    }
}
