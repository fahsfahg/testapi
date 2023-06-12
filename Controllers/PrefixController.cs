using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TestApi.Services;
using TestApi.Models.Prefix;
using AutoMapper;
using TestApi.Helpers;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrefixController : ControllerBase
    {

        private IPrefixService _prefixService;
        private IMapper _mapper;
        public PrefixController(
        IPrefixService prefixService,
        IMapper mapper)
        {
            _prefixService = prefixService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prefix = await _prefixService.GetAll();
            return Ok(prefix);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _prefixService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            await _prefixService.Create(model);
            return Ok(new { message = "User created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TbJobprefix tb_jobprefix)
        {
            await _prefixService.Update(id, tb_jobprefix);
            return Ok(new { message = "User updated" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _prefixService.Delete(id);
            return Ok(new { message = "User deleted" });
        }

    }
}
