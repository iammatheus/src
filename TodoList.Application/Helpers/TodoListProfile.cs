using AutoMapper;
using TodoList.Domain;
using TodoList.Application.Dtos;
using TodoList.Domain.Identity;

namespace TodoList.API.Helpers
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}