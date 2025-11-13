using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Contract.Service;
using ToDoList.Domain.Core.Dtos;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Service
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoRepo;

        public ToDoItemService(IToDoItemRepository toDoRepo)
        {
            _toDoRepo = toDoRepo;
        }

        public List<ToDoItemDto> GetUserItems(int userId)
        {
            return _toDoRepo.GetUserItems(userId);
        }

        public ToDoItemDto? GetItemById(int id)
        {
            return _toDoRepo.GetById(id);
        }

        public ToDoItemDto AddItem(CreateToDoItemDto dto)
        {
            return _toDoRepo.Add(dto);
        }

        public ToDoItemDto? UpdateStatus(int id, ToDoStatus status)
        {
            return _toDoRepo.UpdateStatus(id, status);
        }

        public bool DeleteItem(int id)
        {
            return _toDoRepo.Delete(id);
        }
    }
}

