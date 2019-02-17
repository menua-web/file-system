using System.IO;

namespace Application.Helpers
{
    public static class Folder
    {
        public static void CreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
