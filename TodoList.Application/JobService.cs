using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contratos;
using TodoList.Application.Dtos;
using TodoList.Domain;
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

        public async Task<JobDto> AddJob(int userId, JobDto model)
        {
            try
            {
                var task = _mapper.Map<Job>(model);
                task.UserId = userId;
                _geralPersist.Add(task);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var taskRetorno = await _taskPersist.GetJobByIdAsync(userId, task.Id);
                    return _mapper.Map<JobDto>(taskRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteJob(int userId, int taskId)
        {
            try
            {
                var task = await _taskPersist.GetJobByIdAsync(userId, taskId);
                if (task == null) throw new Exception("Erro ao excluir tag. Tag não encontrado!");

                _geralPersist.Delete(task);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<JobDto[]> GetAllJobAsync(int userId)
        {
            try
            {
                var tasks = await _taskPersist.GetAllJobAsync(userId);
                if (tasks == null) return null;

                var resultado = _mapper.Map<JobDto[]>(tasks);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JobDto> GetJobByIdAsync(int userId, int taskId)
        {
            try
            {
                var task = await _taskPersist.GetJobByIdAsync(userId, taskId);
                if (task == null) return null;

                var resultado = _mapper.Map<JobDto>(task);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<JobDto> UpdateJob(int userId, int taskId, JobDto model)
        {
            try
            {
                var task = await _taskPersist.GetJobByIdAsync(userId, taskId);
                if (task == null) return null;

                model.Id = task.Id;
                model.UserId = userId;

                _mapper.Map(model, task);
                _geralPersist.Update(task);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var taskRetorno = await _taskPersist.GetJobByIdAsync(userId, task.Id);
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
