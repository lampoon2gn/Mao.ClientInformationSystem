using Mao.ClientInformationSystem.Core.Entities;
using Mao.ClientInformationSystem.Core.Models.Request;
using Mao.ClientInformationSystem.Core.Models.Response;
using Mao.ClientInformationSystem.Core.RepoInterfaces;
using Mao.ClientInformationSystem.Core.ServiceInterfacs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mao.ClientInformationSystem.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepo _clientRepo;

        public ClientService(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }
        public async Task<string> AddClient(AddClientRequestModel model)
        {
            var c = new Clients
            {
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,

            };
            var res = await _clientRepo.AddAsync(c);
            return res.Name;
        }

        public async Task<string> DeleteClient(int id)
        {
            var c = await _clientRepo.GetByIdAsync(id);
            await _clientRepo.DeleteAsync(c);
            return c.Name;
        }

        public async Task<string> UpdateClient(AddClientRequestModel model)
        {
            var c = await _clientRepo.GetByIdAsync(model.Id);

            c.Name = model.Name;
            c.Email = model.Email;
            c.Phones = model.Phones;
            c.Address = model.Address;

            var res = await _clientRepo.UpdateAsync(c);
            return res.Name;
        }

        public async Task<IEnumerable<ListClientResponseModel>> ListClient()
        {
            var res = await _clientRepo.ListAllAsync();
            var modelList = new List<ListClientResponseModel>();

            foreach (var client in res)
            {
                var m = new ListClientResponseModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phones = client.Phones,
                    Address = client.Address,
                    AddedOn = client.AddedOn
                };
                modelList.Add(m);

            }
            return modelList;
        }

        public async Task<AddClientResponseModel> GetClientById(int id)
        {
            var c = await _clientRepo.GetByIdAsync(id);
            var r = new AddClientResponseModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phones = c.Phones,
                Address = c.Address,
                AddedOn = c.AddedOn
            };
            return r;
        }
    }
}
