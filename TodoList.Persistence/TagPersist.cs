using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain;
using TodoList.Persistence.Contextos;
using TodoList.Persistence.Contratos;

namespace TodoList.Persistence
{
    public class TagPersist : ITagPersist
    {
        private readonly TodoListContext _context;
        public TagPersist(TodoListContext context)
        {
            _context = context;
        }

        public async Task<Tag[]> GetAllTagsAsync(int userId)
        {
            IQueryable<Tag> query = _context.Tags;

            query = query
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int userId, int tagId)
        {
            IQueryable<Tag> query = _context.Tags;

            query = query
                .AsNoTracking()
                .OrderBy(j => j.Id)
                .Where(j => j.Id == tagId && j.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}