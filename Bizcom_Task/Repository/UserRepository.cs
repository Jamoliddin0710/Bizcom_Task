using Bizcom_Task.Entities.Model;
using Bizcom_Task.Repository.RepositoryContract;
using Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User>? GetUserById(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.Id == userId);

            if (user == null)
                throw new EntityNotFoundException<User>();
            return user;
        }

        public async Task<User>? SignInUser(string phone, string password)
        {
            var user = await context.Users.Where(user => user.PhoneNumber.Equals(phone) && user.Password.Equals(password)).SingleOrDefaultAsync();
            return user;
        }

        public async Task SignUpUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            context.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
