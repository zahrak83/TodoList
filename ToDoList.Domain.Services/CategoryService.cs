using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Contract.Service;
using ToDoList.Domain.Core.Dtos;

namespace ToDoList.Domain.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _categoryRepo.GetAll();
        }

        public CategoryDto? GetCategoryById(int id)
        {
            return _categoryRepo.GetById(id);
        }
    }
}
