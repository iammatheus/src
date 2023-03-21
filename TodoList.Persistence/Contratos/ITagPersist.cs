using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Persistence.Contratos
{
    public interface ITagPersist
    {
        Task<Tag[]> GetAllTagsAsync();
        Task<Tag> GetTagByIdAsync(int tagId);
    }
}