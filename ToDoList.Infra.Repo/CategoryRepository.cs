using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Dtos;
using ToDoList.Infra.Database;

namespace ToDoList.Infra.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAll()
        {
            return _context.categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
        }

        public CategoryDto? GetById(int id)
        {
            return _context.categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).FirstOrDefault();
        }
    }
}

