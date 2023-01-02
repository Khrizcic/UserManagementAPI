using UserManagementAPI.Data;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService : IUser
    {
        private GraphQLDbContext _dbContext;
        public UserService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var userObj = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(userObj);
            _dbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User UpdateUser(int id, User user)
        {
            var userObj = _dbContext.Users.Find(id);
            userObj.Nombre = user.Nombre;
            userObj.ApellidoMaterno = user.ApellidoMaterno;
            userObj.ApellidoPaterno = user.ApellidoPaterno;
            userObj.Telefono = user.Telefono;
            userObj.Direccion = user.Direccion;
            userObj.Email = user.Email;
            _dbContext.SaveChanges();
            return user;
        }
    }
}
