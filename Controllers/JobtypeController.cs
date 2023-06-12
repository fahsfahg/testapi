using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services;
using TestApi.Models;
using AutoMapper;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobtypeController : ControllerBase
    {

        private IJobtypeService _jobtypeService;
        private IMapper _mapper;

        public JobtypeController(
            IJobtypeService jobtypeService,
            IMapper mapper)
        {
            _jobtypeService = jobtypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobtype = await _jobtypeService.GetAll();
            return Ok(jobtype);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TbJobtype model)
        {
            await _jobtypeService.Create(model);
            return Ok(new { message = "User created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobtypeService.Delete(id);
            return Ok(new { message = "User deleted" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]TbJobtype tbJobtype)
        {
            await _jobtypeService.Update(id, tbJobtype);
            return Ok(new { message = "User updated" });
        }

    }
}
