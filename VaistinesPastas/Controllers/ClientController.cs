using Compliance.AssociatedAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaistinesPastas.Repository.Models;
using VaistinesPastas.Services.Interfaces;

namespace VaistinesPastas.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet("ReturnClientList")]
        [ProducesResponseType(typeof(List<Client>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<Client> ReturnClientList()
        {
            return _clientService.ReturnClientList();
        }

        [HttpPost("ImportClientList")]
        [ProducesResponseType(typeof(List<Client>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<Client> ImportClientList(IFormFile file)
        {
            return _clientService.ImportClientList(file);
        }

        [HttpPost("UpdateClientListPosts")]
        [ProducesResponseType(typeof(List<Client>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public Task<List<Client>> UpdateClientListPosts()
        {
            return _clientService.UpdateAllClientPost();
        }
    }
}
