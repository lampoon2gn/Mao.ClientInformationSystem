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
    public class IntService : IIntService
    {
        private readonly IIntRepo _intRepo;

        public IntService(IIntRepo intRepo)
        {
            _intRepo = intRepo;
        }
        public async Task<AddIntResponseModel> AddInt(AddIntRequestModel model)
        {
            var i = new Interactions
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks

            };
            var res = await _intRepo.AddAsync(i);
            var resModel = new AddIntResponseModel
            {
                Id = res.Id,
                EmpId = res.EmpId,
                ClientId = res.ClientId,
                IntDate = res.IntDate
            };
            return resModel;
        }

        public async Task<AddIntResponseModel> DeleteInt(int id)
        {
            var c = await _intRepo.GetByIdAsync(id);
            await _intRepo.DeleteAsync(c);
            var resModel = new AddIntResponseModel
            {
                Id = c.Id,
                EmpId = c.EmpId,
                ClientId = c.ClientId,
                IntDate = c.IntDate
            };
            return resModel;
        }

        public async Task<IEnumerable<ListIntResponseModel>> ListIntByClient(int id)
        {
            var l = await _intRepo.ListAsync(l=>l.ClientId==id);
            var modelList = new List<ListIntResponseModel>();

            foreach (var i in l)
            {
                var m = new ListIntResponseModel
                {
                    Id=i.Id,
                    ClientId = i.ClientId,
                    EmpId = i.EmpId,
                    IntType = i.IntType,
                    IntDate = i.IntDate
                };
                modelList.Add(m);
            }
            return modelList;

        }

        public async Task<IEnumerable<ListIntResponseModel>> ListIntByEmp(int id)
        {
            var l = await _intRepo.ListAsync(l => l.EmpId == id);
            var modelList = new List<ListIntResponseModel>();

            foreach (var i in l)
            {
                var m = new ListIntResponseModel
                {
                    Id = i.Id,
                    ClientId = i.ClientId,
                    EmpId = i.EmpId,
                    IntType = i.IntType,
                    IntDate = i.IntDate
                };
                modelList.Add(m);
            }
            return modelList;
        }

        public async Task<AddIntResponseModel> UpdateInt(AddIntRequestModel model)
        {
            var i = await _intRepo.GetByIdAsync(model.Id);

            i.ClientId = model.ClientId;
            i.EmpId = model.EmpId;
            i.IntType = model.IntType;
            i.IntDate= model.IntDate;
            i.Remarks = model.Remarks;

            var res = await _intRepo.UpdateAsync(i);

            var resModel = new AddIntResponseModel
            {
                Id = res.Id,
                EmpId = res.EmpId,
                ClientId = res.ClientId,
                IntDate = res.IntDate
            };
            return resModel;
        }
    }
}
