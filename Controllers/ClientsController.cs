using BankingControlPanel.Models;
using BankingControlPanel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingControlPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClient = await _clientService.AddClient(client);
            return CreatedAtAction(nameof(GetClient), new { id = createdClient.Id }, createdClient);
        }

        [HttpGet]
        public async Task<IActionResult> GetClients(string filter = "", int page = 1, int pageSize = 10)
        {
            var clients = await _clientService.GetClients(filter, page, pageSize);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
        {
            if (id != client.Id || !ModelState.IsValid)
                return BadRequest();

            await _clientService.UpdateClient(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClient(id);
            return NoContent();
        }
    }
}
