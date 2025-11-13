using ToDoList.Domain.Core.Dtos;

namespace ToDoList.Domain.Core.Contract.Service
{
    public interface IUserService
    {
        UserDto Register(RegisterDto dto);
        UserDto? Login(string mobile, string password);
        UserDto? GetUserById(int id);
    }
}
