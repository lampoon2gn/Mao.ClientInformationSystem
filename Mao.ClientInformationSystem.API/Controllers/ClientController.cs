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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        //[Route("Client")]
        public async Task<IActionResult> AddClient(AddClientRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _clientService.AddClient(model);
                return Ok();
            }
            return BadRequest("Please check the info you entered");
        }

        [HttpDelete]
        [Route("{clientId:int}")]
        public async Task<IActionResult> DelClient(int clientId)
        {
            var res = await _clientService.DeleteClient(clientId);
            return Ok();
        }

        [HttpPut]
        //[Route("Client")]
        public async Task<IActionResult> UpdateClient(AddClientRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _clientService.UpdateClient(model);
                return Ok();
            }
            return BadRequest("Please check the info you entered");
        }

        [HttpGet]
        //[Route("Clients")]
        public async Task<IActionResult> ListClient()
        {
            var res = await _clientService.ListClient();
            return Ok(res);
        }

        [HttpGet]
        [Route("{clientId:int}")]
        public async Task<IActionResult> GetEmpById(int clientId)
        {
            var res = await _clientService.GetClientById(clientId);
            return Ok(res);
        }
    }
}
