using Mao.ClientInformationSystem.Core.Models.Request;
using Mao.ClientInformationSystem.Core.ServiceInterfacs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mao.ClientInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService _empService;
        public EmpController(IEmpService empService)
        {
            _empService = empService;
        }

        [HttpPost]
        //[Route("Emp")]
        public async Task<IActionResult> AddEmp(AddEmpRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _empService.AddEmp(model);
                return Ok(res);
            }
            return BadRequest("Please check the info you entered");
        }

        [HttpDelete]
        [Route("{empId:int}")]
        public async Task<IActionResult> DelEmp(int empId)
        {
            var res = await _empService.DeleteEmp(empId);
            return Ok(res);
        }

        [HttpPut]
        //[Route("Emp")]
        public async Task<IActionResult> UpdateEmp(AddEmpRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _empService.UpdateEmp(model);
                return Ok(res);
            }
            return BadRequest("Please check the info you entered");
        }

        [HttpGet]
        //[Route("Emps")]
        public async Task<IActionResult> ListEmp()
        {
            var res = await _empService.ListEmp();
            return Ok(res);
        }

    }
}
