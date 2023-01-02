using UserManagementAPI.Models;

namespace UserManagementAPI.Interfaces
{
    public interface IUser
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User AddUser(User user);
        User UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
