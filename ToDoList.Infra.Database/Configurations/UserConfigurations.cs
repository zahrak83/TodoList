using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Core.Entities;

namespace ToDoList.Infra.Database.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User { Id = 1, FName = "zahra", LName = "keshavarzian", Mobile = "09102882094", Password = "1234" }
               );
        }
    }
}
