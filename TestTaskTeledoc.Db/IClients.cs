using TestTaskTeledoc.Db.Models;

namespace TestTaskTeledoc.Db
{
    public interface IClients
    {
        Client? GetClient(Guid id);
        Task<List<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task<Client?> UpdatePumpAsync(Client client, Client newClient);
        Task RemoveAsync(Client client);
    }
}