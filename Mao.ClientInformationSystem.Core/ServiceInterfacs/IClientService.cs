using Mao.ClientInformationSystem.Core.Models.Request;
using Mao.ClientInformationSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mao.ClientInformationSystem.Core.ServiceInterfacs
{
    public interface IClientService
    {
        Task<string> AddClient(AddClientRequestModel model);
        Task<string> DeleteClient(int id);
        Task<string> UpdateClient(AddClientRequestModel model);
        Task<IEnumerable<ListClientResponseModel>> ListClient();

    }
}
