using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoList.API.Extensions;
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
        
        public JobController(
            IJobService jobService,
            IWebHostEnvironment hostEnvironment)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var job = await _jobService.GetAllJobAsync(User.GetUserId());
                if (job == null) return NoContent();

                return Ok(job);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar as tasks. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var job = await _jobService.GetJobByIdAsync(User.GetUserId(), id);
                if (job == null) return NoContent();
                return Ok(job);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Tarefa não encontrada. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobDto model)
        {
            try
            {
                var job = await _jobService.AddJob(User.GetUserId(), model);
                if (job == null) return NoContent();
                return Ok(job);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar tarefa. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, JobDto model)
        {
            try
            {
                var job = await _jobService.UpdateJob(User.GetUserId(), id, model);
                if (job == null) return NoContent();
                return Ok(job);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar tarefa. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var job = await _jobService.GetJobByIdAsync(User.GetUserId(), id);
                if (job == null) return NoContent();

                if (await _jobService.DeleteJob(User.GetUserId(), id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao deletar a tarefa.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar tarefa. Erro: {ex.Message}");
            }
        }
    }
}
