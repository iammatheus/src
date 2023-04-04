using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Persistence.Contratos
{
    public interface IJobPersist
    {

        Task<Job[]> GetAllJobAsync();
        Task<Job> GetJobByIdAsync(int jobId);
        
    }
}
