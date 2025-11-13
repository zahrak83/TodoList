using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Dtos
{
    public class CreateToDoItemDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public ToDoStatus Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
