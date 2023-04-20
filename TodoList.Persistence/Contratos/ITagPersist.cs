using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Persistence.Contratos
{
    public interface ITagPersist
    {
        Task<Tag[]> GetAllTagsAsync(int userId);
        Task<Tag> GetTagByIdAsync(int userId, int tagId);
    }
}