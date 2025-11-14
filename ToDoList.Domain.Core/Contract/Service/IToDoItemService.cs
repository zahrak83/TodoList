using ToDoList.Domain.Core.Dtos;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Contract.Service
{
    public interface IToDoItemService
    {
        List<ToDoItemDto> GetUserItems(int userId);
        ToDoItemDto? GetItemById(int id);
        ToDoItemDto AddItem(CreateToDoItemDto dto);
        ToDoItemDto? UpdateStatus(int id, ToDoStatus status);
        bool DeleteItem(int id);
        List<ToDoItemDto> Filter(int userId, string? search, string? sort);

    }
}
