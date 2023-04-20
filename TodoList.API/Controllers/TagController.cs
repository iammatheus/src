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
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(
            ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tags = await _tagService.GetAllTagsAsync(User.GetUserId());
                if (tags == null) return NoContent();

                return Ok(tags);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar as tags. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var tag = await _tagService.GetTagByIdAsync(User.GetUserId(), id);
                if (tag == null) return NoContent();
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Tag não encontrada. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TagDto model)
        {
            try
            {
                var tag = await _tagService.AddTag(User.GetUserId(), model);
                if (tag == null) return NoContent();
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar tag. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TagDto model)
        {
            try
            {
                var tag = await _tagService.UpdateTag(User.GetUserId(), id, model);
                if (tag == null) return NoContent();
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar tag. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _tagService.GetTagByIdAsync(User.GetUserId(), id);
                if (evento == null) return NoContent();

                if (await _tagService.DeleteTag(User.GetUserId(), id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao deletar a tag.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar tag. Erro: {ex.Message}");
            }
        }
    }
}
