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
    public class IntController : ControllerBase
    {
        private readonly IIntService _intService;
        public IntController(IIntService intService)
        {
            _intService = intService;
        }

        [HttpPost]
        //[Route("Int")]
        public async Task<IActionResult> AddInt(AddIntRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _intService.AddInt(model);
                return Ok(res);
            }
            return BadRequest("Please check the info you entered");
        }

        [HttpDelete]
        [Route("{intId:int}")]
        public async Task<IActionResult> DelInt(int intId)
        {
            var res = await _intService.DeleteInt(intId);
            return Ok(res);
        }

        [HttpPut]
        //[Route("Int")]
        public async Task<IActionResult> UpdateInt(AddIntRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _intService.UpdateInt(model);
                return Ok(res);
            }
            return BadRequest("Please check the info you entered");
        }

        [HttpGet]
        [Route("emp/{empId:int}")]
        public async Task<IActionResult> ListIntByEmp(int empId)
        {
            var res = await _intService.ListIntByEmp(empId);
            return Ok(res);
        }

        [HttpGet]
        [Route("client/{clientId:int}")]
        public async Task<IActionResult> ListIntByClient(int clientId)
        {
            var res = await _intService.ListIntByClient(clientId);
            return Ok(res);
        }
    }
}
