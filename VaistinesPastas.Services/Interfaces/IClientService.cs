using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaistinesPastas.Repository.Models;

namespace VaistinesPastas.Services.Interfaces
{
    public interface IClientService
    {
        public List<Client> ReturnClientList();
        public List<Client> ImportClientList(IFormFile file);
        public Task<List<Client>> UpdateAllClientPost();

    }
}
