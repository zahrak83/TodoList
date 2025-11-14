using ToDoList.Domain.Core.Dtos;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Contract.Repo
{
    public interface IToDoItemRepository
    {
        List<ToDoItemDto> GetUserItems(int userId);
        ToDoItemDto? GetById(int id);
        ToDoItemDto Add(CreateToDoItemDto item);
        ToDoItemDto? UpdateStatus(int id, ToDoStatus status);
        bool Delete(int id);
        List<ToDoItemDto> Filter(int userId, string? search, string? sort);

    }
}
