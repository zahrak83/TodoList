using ToDoList.Domain.Core.Dtos;

namespace ToDoList.Domain.Core.Contract.Repo
{
    public interface ICategoryRepository
    {
        List<CategoryDto> GetAll();
        CategoryDto? GetById(int id);
    }
}
