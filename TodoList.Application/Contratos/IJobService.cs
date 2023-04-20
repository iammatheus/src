using TodoList.Application.Dtos;
using System.Threading.Tasks;

namespace TodoList.Application.Contratos
{
    public interface IJobService
    {
        Task<JobDto> AddJob(int userId, JobDto model);
        Task<JobDto> UpdateJob(int userId, int jobId, JobDto model);
        Task<bool> DeleteJob(int userId, int jobId);
        Task<JobDto[]> GetAllJobAsync(int userId);
        Task<JobDto> GetJobByIdAsync(int userId, int jobId);
    }
}
