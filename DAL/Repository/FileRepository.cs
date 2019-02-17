using DAL.Contexts;
using DAL.Exceptions;
using Domain.Entities;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly FileSystemContext _fsContext;
        private readonly DbSet<File> _files;
        public FileRepository(FileSystemContext fsContext)
        {
            _fsContext = fsContext;
            _files = fsContext.Set<File>();
        }

        public long Create(File newFile)
        {
            newFile.Create();
            _files.Add(newFile);
            _fsContext.SaveChanges();
            return newFile.ID;
        }

        public void Delete(long id)
        {
            File deletingFile = _files.Find(id) ?? throw new EntityNotFoundException(id);
            _fsContext.Remove(deletingFile);
            _fsContext.SaveChanges();
        }

        public File Get(long id)
        {
            return _files.Find(id);
        }

        public IEnumerable<File> GetAll()
        {
            return _files.AsNoTracking().ToList();
        }

        public void Modify(File file)
        {
            _files.Update(file);
            _fsContext.SaveChanges();
        }
    }
}
