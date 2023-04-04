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

        public async Task<Job[]> GetAllJobAsync()
        {
            IQueryable<Job> query = _context.Jobs;
            query = query.AsNoTracking()
               .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Job> GetJobByIdAsync(int jobId)
        {
            IQueryable<Job> query = _context.Jobs;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => e.Id == jobId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
