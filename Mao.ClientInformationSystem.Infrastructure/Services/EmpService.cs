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
    public class EmpService : IEmpService
    {
        private readonly IEmpRepo _empRepo;

        public EmpService(IEmpRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<string> AddEmp(AddEmpRequestModel model)
        {
            var e = new Employees
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation,
            };
            var res = await _empRepo.AddAsync(e);
            return res.Name;
        }

        public async Task<string> DeleteEmp(int id)
        {
            var e = await _empRepo.GetByIdAsync(id);
            await _empRepo.DeleteAsync(e);
            return e.Name;
        }

        public async Task<AddEmpResponseModel> GetEmpById(int id)
        {
            var e = await _empRepo.GetByIdAsync(id);
            var r = new AddEmpResponseModel
            {
                Id=e.Id,
                Name=e.Name,
                Password=e.Password,
                Designation=e.Designation
            };
            return r;
        }

        public async Task<IEnumerable<ListEmpResponseModel>> ListEmp()
        {
            var res = await _empRepo.ListAllAsync();
            var modelList = new List<ListEmpResponseModel>();
            
            foreach (var emp in res)
            {
                var m = new ListEmpResponseModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Designation = emp.Designation
                };
                modelList.Add(m);

            }
            return modelList;
        }

        public async Task<string> UpdateEmp(AddEmpRequestModel model)
        {
            var e = await _empRepo.GetByIdAsync(model.Id);

            e.Name = model.Name;
            e.Password = model.Password;
            e.Designation = model.Designation;

            var res = await _empRepo.UpdateAsync(e);
            return res.Name;
        }
    }
}
