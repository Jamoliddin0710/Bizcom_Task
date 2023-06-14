using Bizcom_Task.Entities.Model;

namespace Bizcom_Task.Repository.RepositoryContract
{
    public interface IUserRepository
    {
        Task SignUpUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(int userId);
        Task<User> SignInUser(string phone, string password);
    }
}
