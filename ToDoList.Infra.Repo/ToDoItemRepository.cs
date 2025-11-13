using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Dtos;
using ToDoList.Domain.Core.Entities;
using ToDoList.Domain.Core.Enums;
using ToDoList.Infra.Database;

namespace ToDoList.Infra.Repo
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _context;
        public ToDoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ToDoItemDto> GetUserItems(int userId)
        {
            return _context.toDoItems
                .Where(t => t.UserId == userId)
                .Select(t => new ToDoItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status,
                    CategoryName = t.Category!.Name
                })
                .ToList();
        }

        public ToDoItemDto? GetById(int id)
        {
            return _context.toDoItems
                .Where(t => t.Id == id)
                .Select(t => new ToDoItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status,
                    CategoryName = t.Category!.Name
                })
                .FirstOrDefault();
        }

        public ToDoItemDto Add(CreateToDoItemDto dto)
        {
            var entity = new ToDoItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                CategoryId = dto.CategoryId,
                UserId = dto.UserId,
                Status = ToDoStatus.NotDone
            };

            _context.toDoItems.Add(entity);
            _context.SaveChanges();

            return new ToDoItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Status = entity.Status,
                CategoryName = _context.categories.FirstOrDefault(c => c.Id == entity.CategoryId)?.Name
            };
        }

        public ToDoItemDto? UpdateStatus(int id, ToDoStatus status)
        {
            var entity = _context.toDoItems.FirstOrDefault(t => t.Id == id);
            if (entity == null)
                return null;

            entity.Status = status;
            _context.SaveChanges();

            var categoryName = _context.categories
                .Where(c => c.Id == entity.CategoryId)
                .Select(c => c.Name)
                .FirstOrDefault();

            return new ToDoItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Status = entity.Status,
                CategoryName = categoryName
            };
        }

        public bool Delete(int id)
        {
            var entity = _context.toDoItems.Find(id);
            if (entity == null) 
                return false;

            _context.toDoItems.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}