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
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TagController(
            ITagService tagService,
            IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tags = await _tagService.GetAllTagsAsync();
                if (tags == null) return NoContent();

                return Ok(tags);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar as tags. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TagDto model)
        {
            try
            {
                var tag = await _tagService.AddTag(model);
                if (tag == null) return NoContent();
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar tag. Erro: {ex.Message}");
            }
        }
    }
}
