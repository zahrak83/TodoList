using ToDoList.Domain.Core.Dtos;

namespace ToDoList.Domain.Core.Contract.Repo
{
    public interface IUserRepository
    {
        UserDto? GetById(int id);
        UserDto? GetByMobile(string mobile);
        bool Exists(string mobile, string password);
        UserDto Add(RegisterDto user);
    }
}
