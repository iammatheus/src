using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoList.Application.Contratos;
using TodoList.Application.Dtos;

namespace TodoList.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public JobController(
            IJobService jobService,
            IWebHostEnvironment hostEnvironment)
        {
            _jobService = jobService;
            _hostEnvironment = hostEnvironment;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var job = await _jobService.GetAllJobAsync();
                if (job == null) return NoContent();

                return Ok(job);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar as tasks. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobDto model)
        {
            try
            {
                var job = await _jobService.AddJob(model);
                if (job == null) return NoContent();
                return Ok(job);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar task. Erro: {ex.Message}");
            }
        }
    }
}
