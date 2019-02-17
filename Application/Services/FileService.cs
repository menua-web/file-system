using Application.Enums;
using Application.Helpers;
using Application.IServices;
using DAL.Repository;
using Domain.Entities;
using DtoModels.EntityDtoModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using IO = System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Exceptions;
using Domain.Extensions;
using Application.Descriptors;

namespace Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileAsyncRepository _fileRepo;
        private readonly IHostingEnvironment _env;
        private readonly IMapper _mapper;
        public FileService(
            IFileAsyncRepository fileRepo,
            IHostingEnvironment env,
            IMapper mapper)
        {
            _fileRepo = fileRepo;
            _mapper = mapper;
            _env = env;
        }

        public async Task<long> CreateAsync(FileDto newFile)
        {
            FileDescriptor fileDesc = new FileDescriptor(newFile, _env);
            Folder.CreateIfNotExists(fileDesc.Path);
            File file = new File(fileDesc.Path, fileDesc.Name, fileDesc.Extension);
            await fileDesc.Override(file);
            return await _fileRepo.CreateAsync(file);
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                File deletingFile = await _fileRepo.GetAsync(id);
                string _path = IO.Path.Combine(deletingFile.Path, deletingFile.FileName + deletingFile.Extension);
                IO.File.Delete(_path);
                await _fileRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FileDto>> GetAsync()
        {
            var files = await _fileRepo.GetAllAsync();
            return _mapper.Map<List<FileDto>>(files);
        }

        public async Task<FileDto> GetAsync(long id)
        {
            var file = await _fileRepo.GetAsync(id);
            return _mapper.Map<FileDto>(file);
        }

        public async Task UpdateAsync(FileDto file)
        {
            try
            {
                File puttingFile = await _fileRepo.GetAsync(file.ID) ?? throw new EntityNotFoundException(file.ID);
                IO.File.Delete(puttingFile.ToString());
                FileDescriptor fileDesc = new FileDescriptor(file, _env);

                puttingFile.FileName = fileDesc.Name;
                puttingFile.Path = fileDesc.Path;
                puttingFile.Extension = fileDesc.Extension;

                await fileDesc.Override(puttingFile);
                await _fileRepo.ModifyAsync(puttingFile, file.ID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
