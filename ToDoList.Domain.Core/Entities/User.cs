namespace ToDoList.Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? LName { get; set; }
        public string? FName { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public List<ToDoItem>? Items { get; set; }
    }
}
