using DAL.Infrastructures.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    public class FileSystemContext : DbContext
    {
        public FileSystemContext(DbContextOptions<FileSystemContext> option): base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FileEntityConfiguration());
        }

        public DbSet<File> Files { get; set; }
    }
}
