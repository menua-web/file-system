using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IFileAsyncRepository
    {
        Task<IEnumerable<File>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<File> GetAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
        Task<long> CreateAsync(File newFile, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
        Task ModifyAsync(File file, long id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
