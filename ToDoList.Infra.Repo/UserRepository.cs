using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Dtos;
using ToDoList.Domain.Core.Entities;
using ToDoList.Infra.Database;

namespace ToDoList.Infra.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserDto? GetById(int id)
        {
            return _context.users
                .Where(u => u.Id == id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FName = u.FName,
                    LName = u.LName,
                    Mobile = u.Mobile
                })
                .FirstOrDefault();
        }

        public UserDto? GetByMobile(string mobile)
        {
            return _context.users
                .Where(u => u.Mobile == mobile)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FName = u.FName,
                    LName = u.LName,
                    Mobile = u.Mobile
                })
                .FirstOrDefault();
        }

        public bool Exists(string mobile, string password)
        {
            return _context.users
                .Any(u => u.Mobile == mobile && u.Password == password);
        }

        public UserDto Add(RegisterDto dto)
        {
            var entity = new User
            {
                FName = dto.FName,
                LName = dto.LName,
                Mobile = dto.Mobile,
                Password = dto.Password
            };

            _context.users.Add(entity);
            _context.SaveChanges();

            return new UserDto
            {
                Id = entity.Id,
                FName = entity.FName,
                LName = entity.LName,
                Mobile = entity.Mobile
            };
        }
    }
}


