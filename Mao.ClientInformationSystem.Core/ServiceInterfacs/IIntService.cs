using Mao.ClientInformationSystem.Core.Models.Request;
using Mao.ClientInformationSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mao.ClientInformationSystem.Core.ServiceInterfacs
{
    public interface IIntService
    {
        Task<AddIntResponseModel> AddInt(AddIntRequestModel model);
        Task<AddIntResponseModel> DeleteInt(int id);
        Task<AddIntResponseModel> UpdateInt(AddIntRequestModel model);
        Task<IEnumerable<ListIntResponseModel>> ListIntByEmp(int id);
        Task<IEnumerable<ListIntResponseModel>> ListIntByClient(int id);
        Task<AddIntResponseModel> GetIntById(int id);
    }
}
