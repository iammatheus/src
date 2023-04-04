using AutoMapper;
using TodoList.Domain;
using TodoList.Application.Dtos;

namespace TodoList.API.Helpers
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();

        }
    }
}