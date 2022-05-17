using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VaistinesPastas.Repository.Data;
using VaistinesPastas.Repository.Models;
using VaistinesPastas.Services.Interfaces;

namespace VaistinesPastas.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly PastoIndeksaiContext _context;
        private static readonly HttpClient _httpClient = new HttpClient();
        private IConfiguration _configuration;

        public ClientService(PastoIndeksaiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<Client> ReturnClientList()
        {
            return _context.Clients.ToList();
        }

        public List<Client> ImportClientList(IFormFile file)
        {
            List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(ConvertFileToString(file));

            foreach(Client client in clients)
            {
                if(!CheckClientExist(client.Name, client.Address))
                {
                    _context.Clients.Add(client);
                }
            }
            _context.SaveChanges();
            return clients;
        }

        // Used to query https://postit.lt/API/
        public async Task<List<Client>> UpdateAllClientPost()
        {           
            foreach (Client client in _context.Set<Client>().ToList())
            {
                var postITResponse = JsonConvert.DeserializeObject<PostITResponse>(
                    await _httpClient.GetStringAsync(_configuration.GetConnectionString("PostITURL") 
                    + "/?term=" + client.Address + "&key=" + _configuration.GetConnectionString("PostITApiKey")));

                try
                {
                    client.PostCode = postITResponse.data.FirstOrDefault().post_code;
                }
                catch (NullReferenceException ex)
                {
                }

                _context.Clients.Update(client);
            }
            _context.SaveChanges();
            
            return _context.Set<Client>().ToList();
        }

        private bool CheckClientExist(string name, string address)
        {
            return _context.Set<Client>()
                .Where(c => c.Name == name && c.Address == address)
                .Select(c=> c.ClientId)
                .Any();
        }

        private string ConvertFileToString(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
