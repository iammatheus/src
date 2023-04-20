using System.Threading.Tasks;
using TodoList.Application.Dtos;

namespace TodoList.Application.Contratos
{
    public interface ITagService
    {
        Task<TagDto> AddTag(int userId, TagDto model);
        Task<TagDto> UpdateTag(int userId, int tagId, TagDto model);
        Task<bool> DeleteTag(int userId, int tagId);
        Task<TagDto[]> GetAllTagsAsync(int userId);
        Task<TagDto> GetTagByIdAsync(int userId, int tagId);
    }
}
