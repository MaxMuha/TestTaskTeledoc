using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TestTaskTeledoc.Db.Models;

namespace TestTaskTeledoc.Db
{
    public class ClientsDbRepository : IClients
    {
        private readonly DatabaseContext databaseContext;
        public ClientsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public Client? GetClient(Guid id)   //Просмотр
        {
            return databaseContext.Clients.Include(x => x.Founders).FirstOrDefault(x => x.Id == id);
        }
        public async Task<List<Client>> GetAllAsync()
        {
            return await databaseContext.Clients.Include(x => x.Founders).ToListAsync();
        }
        public async Task AddAsync(Client client)   //Добавление
        {
            await databaseContext.Clients.AddAsync(client);

            await databaseContext.SaveChangesAsync();
        }
        public async Task<Client> UpdatePumpAsync(Client client, Client newClient)  //Редактирование
        {
            client.TaxpayerIdentification = newClient.TaxpayerIdentification;
            client.Name = newClient.Name;
            client.Type = newClient.Type;
            client.DateUpdate = newClient.DateUpdate;
            for (int i = 0; i < client.Founders.Count; i++)
            {
                client.Founders[i].TaxpayerIdentification = newClient.Founders[i].TaxpayerIdentification;
                client.Founders[i].FullName = newClient.Founders[i].FullName;
                client.Founders[i].DateUpdate = newClient.Founders[i].DateUpdate;
            }

            await databaseContext.SaveChangesAsync();

            return client;
        }
        public async Task RemoveAsync(Client client)    //Удаление
        {
            databaseContext.Clients.Remove(client);

            await databaseContext.SaveChangesAsync();
        }
    }
}
