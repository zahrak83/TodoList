using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Core.Entities;

namespace ToDoList.Infra.Database.Configurations
{
    public class ToDoItemConfigurations : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ToDoItem> builder)
        {
        }
    }
}
