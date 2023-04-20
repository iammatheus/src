using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Persistence.Contextos;
using TodoList.Persistence.Contratos;

namespace TodoList.Persistence
{
    public class JobPersist: IJobPersist
    {

        private readonly TodoListContext _context;

        public JobPersist(TodoListContext context)
        {
            _context = context;
        }

        public async Task<Job[]> GetAllJobAsync(int userId)
        {
            IQueryable<Job> query = _context.Jobs;
            query = query.AsNoTracking()
                .Where(j => j.UserId == userId)
               .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Job> GetJobByIdAsync(int userId, int jobId)
        {
            IQueryable<Job> query = _context.Jobs;

            query = query
                .AsNoTracking()
                .OrderBy(j => j.Id)
                .Where(j => j.Id == jobId && j.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
