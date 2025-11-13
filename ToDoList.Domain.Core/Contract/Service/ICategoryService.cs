using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Dtos;

namespace ToDoList.Domain.Core.Contract.Service
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();
        public CategoryDto? GetCategoryById(int id);
    }
}
