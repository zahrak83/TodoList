using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Core.Entities;

namespace ToDoList.Infra.Database.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
               new Category { Id = 1, Name = "شخصی" },
               new Category { Id = 2, Name = "کاری" },
               new Category { Id = 3, Name = "دانشگاهی" },
               new Category { Id = 4, Name = "سایر" }
               );
        }
    }
}
