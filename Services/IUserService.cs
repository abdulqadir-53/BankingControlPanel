using BankingControlPanel.Models;

namespace BankingControlPanel.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(User user);
        Task<User> LoginUser(string email, string password);
    }
}
