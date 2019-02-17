using DAL.Contexts;
using DAL.Exceptions;
using Domain.Entities;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class FileAsyncRepository : IFileAsyncRepository
    {
        private readonly FileSystemContext _fsContext;
        private readonly DbSet<File> _files;
        public FileAsyncRepository(FileSystemContext fsContext)
        {
            _fsContext = fsContext;
            _files = fsContext.Set<File>();
        }

        public async Task<long> CreateAsync(File newFile, CancellationToken cancellationToken = default(CancellationToken))
        {
            newFile.Create();
            await _files.AddAsync(newFile, cancellationToken);
            await _fsContext.SaveChangesAsync(cancellationToken);
            return newFile.ID;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            File deletingFile = await _files.FindAsync(new object[] { id }, cancellationToken) ?? throw new EntityNotFoundException(id);
            _fsContext.Remove(deletingFile);
            await _fsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<File>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _files.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<File> GetAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _files.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task ModifyAsync(File file, long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            _files.Update(file);
            await _fsContext.SaveChangesAsync(cancellationToken);
        }
    }
}
