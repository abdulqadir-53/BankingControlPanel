using BankingControlPanel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingControlPanel.Services
{
    public interface IClientService
    {
        Task<Client> AddClient(Client client);
        Task<IEnumerable<Client>> GetClients(string filter, int page, int pageSize);
        Task<Client> GetClientById(int id);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
