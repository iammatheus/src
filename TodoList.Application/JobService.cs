using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contratos;
using TodoList.Application.Dtos;
using TodoList.Persistence.Contratos;

namespace TodoList.Application
{
    public class JobService : IJobService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IJobPersist _taskPersist;
        private readonly IMapper _mapper;



        public JobService(
            IGeralPersist geralPersist,
            IJobPersist taskPersist,
             IMapper mapper)
        {
            _geralPersist = geralPersist;
            _taskPersist = taskPersist;
            _mapper = mapper;

        }

        public async Task<JobDto> AddJob(JobDto model)
        {
            try
            {
                var task = _mapper.Map<Domain.Job>(model);
                _geralPersist.Add(task);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var taskRetorno = await _taskPersist.GetJobByIdAsync(task.Id);
                    return _mapper.Map<JobDto>(taskRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteJob(int taskId)
        {
            try
            {
                var task = await _taskPersist.GetJobByIdAsync(taskId);
                if (task == null) throw new Exception("Erro ao excluir tag. Tag não encontrado!");

                _geralPersist.Delete<Domain.Job>(task);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<JobDto[]> GetAllJobAsync()
        {
            try
            {
                var tasks = await _taskPersist.GetAllJobAsync();
                if (tasks == null) return null;

                var resultado = _mapper.Map<JobDto[]>(tasks);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JobDto> GetJobByIdAsync(int taskId)
        {
            try
            {
                var task = await _taskPersist.GetJobByIdAsync(taskId);
                if (task == null) return null;

                var resultado = _mapper.Map<JobDto>(task);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<JobDto> UpdateJob(int TaskId, JobDto model)
        {
            try
            {
                var task = await _taskPersist.GetJobByIdAsync(TaskId);
                if (task == null) return null;

                model.Id = task.Id;

                _mapper.Map(model, task);
                _geralPersist.Update(task);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var taskRetorno = await _taskPersist.GetJobByIdAsync(task.Id);
                    return _mapper.Map<JobDto>(taskRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
