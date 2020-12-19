using Mao.ClientInformationSystem.Core.Models.Request;
using Mao.ClientInformationSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mao.ClientInformationSystem.Core.ServiceInterfacs
{
    public interface IEmpService
    {
        Task<string> AddEmp(AddEmpRequestModel model);
        Task<string> DeleteEmp(int id);
        Task<string> UpdateEmp(AddEmpRequestModel model);
        Task<IEnumerable<ListEmpResponseModel>> ListEmp();
        Task<AddEmpResponseModel> GetEmpById(int id);
    }
}
