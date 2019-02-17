using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Infrastructures.Configuration
{
    internal class FileEntityConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Files");

            builder.Property(prop => prop.FileName)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Extension)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(prop => prop.Path)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(prop => prop.CreateDate)
                .HasColumnType("date")
                .IsRequired();
            builder.Property(prop => prop.ModifyDate)
                .HasColumnType("date");
        }
    }
}
