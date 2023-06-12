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
    public class QualityController : ControllerBase
    {
        private IQualityService _qualityService;
        private IMapper _mapper;

        public QualityController(
            IQualityService qualityService,
            IMapper mapper)
        {
            _qualityService = qualityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobtype = await _qualityService.GetAll();
            return Ok(jobtype);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TbQuality tbQuality)
        {
            await _qualityService.Create(tbQuality);
            return Ok(new { message = "QA Name created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _qualityService.Delete(id);
            return Ok(new { message = "QA Name deleted" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]TbQuality tbQuality)
        {
            await _qualityService.Update(id, tbQuality);
            return Ok(new { message = "QA Name updated" });
        }

    }
}
