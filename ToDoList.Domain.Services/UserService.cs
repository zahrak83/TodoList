using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Contract.Service;
using ToDoList.Domain.Core.Dtos;

namespace ToDoList.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public UserDto Register(RegisterDto dto)
        {
            var existing = _userRepo.GetByMobile(dto.Mobile!);
            if (existing != null)
                throw new Exception("کاربر با این شماره موبایل قبلاً ثبت‌نام کرده است.");

            return _userRepo.Add(dto);
        }

        public UserDto? Login(string mobile, string password)
        {
            if (_userRepo.Exists(mobile, password))
                return _userRepo.GetByMobile(mobile);

            return null;
        }

        public UserDto? GetUserById(int id)
        {
            return _userRepo.GetById(id);
        }
    }
}

