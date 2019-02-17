using DtoModels.EntityDtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IFileService
    {
        Task<IEnumerable<FileDto>> GetAsync();
        Task<FileDto> GetAsync(long id);
        Task<long> CreateAsync(FileDto newFile);
        Task UpdateAsync(FileDto file);
        Task DeleteAsync(long id);
    }
}
