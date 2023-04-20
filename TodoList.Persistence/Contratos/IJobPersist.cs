using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Persistence.Contratos
{
    public interface IJobPersist
    {
        Task<Job[]> GetAllJobAsync(int userId);
        Task<Job> GetJobByIdAsync(int userId, int jobId);
    }
}
