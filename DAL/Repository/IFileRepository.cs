using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IFileRepository
    {
        IEnumerable<File> GetAll();
        File Get(long id);
        long Create(File newFile);
        void Delete(long id);
        void Modify(File file);
    }
}
