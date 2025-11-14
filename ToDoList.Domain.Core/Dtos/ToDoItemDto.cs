using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Dtos
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public ToDoStatus Status { get; set; }
        public string? CategoryName { get; set; }
        public bool IsOverdue { get; set; }
    }
}
