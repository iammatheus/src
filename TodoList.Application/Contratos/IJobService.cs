using TodoList.Application.Dtos;
using System.Threading.Tasks;

namespace TodoList.Application.Contratos
{
    public interface IJobService
    {
         Task<JobDto> AddJob(JobDto model);
        Task<JobDto> UpdateJob(int jobId, JobDto model);
        Task<bool> DeleteJob(int jobId);
        Task<JobDto[]> GetAllJobAsync();
        Task<JobDto> GetJobByIdAsync(int jobId);
    }
}
