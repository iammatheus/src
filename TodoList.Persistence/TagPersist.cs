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
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; Aplica AsNoTracking() para todas as funções.
        }

        public async Task<Tag[]> GetAllTagsAsync()
        {
            IQueryable<Tag> query = _context.Tags;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int tagId)
        {
            IQueryable<Tag> query = _context.Tags;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => e.Id == tagId);

            return await query.FirstOrDefaultAsync();
        }
    }
}