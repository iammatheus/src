using System.Threading.Tasks;
using TodoList.Application.Dtos;

namespace TodoList.Application.Contratos
{
    public interface ITagService
    {
        Task<TagDto> AddTag(TagDto model);
        Task<TagDto> UpdateTag(int tagId, TagDto model);
        Task<bool> DeleteTag(int tagId);
        Task<TagDto[]> GetAllTagsAsync();
        Task<TagDto> GetTagByIdAsync(int tagId);
    }
}
