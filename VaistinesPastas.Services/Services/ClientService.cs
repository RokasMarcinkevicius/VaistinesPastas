using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        public ClientService(PastoIndeksaiContext context)
        {
            _context = context;
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
                    await _httpClient.GetStringAsync("https://api.postit.lt/?term=" + client.Address + "&key=postit.lt-examplekey"));
                try
                {
                    if (postITResponse.data.FirstOrDefault().post_code != null)
                    {
                        client.PostCode = postITResponse.data.FirstOrDefault().post_code;
                    }
                }
                catch
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
