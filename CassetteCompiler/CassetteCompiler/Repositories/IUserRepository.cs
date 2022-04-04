using CassetteCompiler.Models;
using System.Collections.Generic;

namespace CassetteCompiler.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetById(int id);
        public User GetByEmail(string email);
        public void AddUser(User user);
    }
}
