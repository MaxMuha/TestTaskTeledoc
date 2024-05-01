using Microsoft.AspNetCore.Mvc;
using TestTaskTeledoc.Db;
using TestTaskTeledoc.Helpers;
using TestTaskTeledoc.Models;

namespace TestTaskTeledoc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClients clientsReposytory;
        public ClientController(IClients clientsReposytory)
        {
            this.clientsReposytory = clientsReposytory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await clientsReposytory.GetAllAsync();

            return Ok(clients.ToClientViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientViewModel clientRequest)
        {
            clientRequest.Id = Guid.NewGuid();
            clientRequest.Founders.ForEach(x => x.Id = Guid.NewGuid());

            await clientsReposytory.AddAsync(clientRequest.ToClient());

            return Ok(clientRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var client = clientsReposytory.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client.ToClientViewModel());
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateClient(Guid id, ClientViewModel updateClientRequest)
        {
            var client = clientsReposytory.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientUpdate = await clientsReposytory.UpdatePumpAsync(client, updateClientRequest.ToClient());

            return Ok(clientUpdate.ToClientViewModel());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = clientsReposytory.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }

            await clientsReposytory.RemoveAsync(client);

            return Ok(client.ToClientViewModel());
        }
    }
}
