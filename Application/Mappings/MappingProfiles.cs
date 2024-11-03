using AutoMapper;
using Domain.Dtos.Category.RequestDtos;
using Domain.Dtos.Category.ResponseDtos;
using Domain.Dtos.Todo.RequestDtos;
using Domain.Dtos.Todo.ResponseDtos;
using Domain.Dtos.User.RequestDtos;
using Domain.Dtos.User.ResponseDtos;
using TodoApp.Domain.Models;

namespace Application.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Todo
        CreateMap<CreateTodoRequestDto, Todo>().ReverseMap();
        CreateMap<UpdateTodoRequestDto, Todo>().ReverseMap();

        CreateMap<Todo, TodoResponseDto>();

		// Category
		CreateMap<CreateCategoryRequestDto, Category>().ReverseMap();
		CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();

		CreateMap<Category, CategoryResponseDto>();

		// User And Auth
		CreateMap<RegisterRequestDto, User>().ReverseMap();
		CreateMap<User, UserResponseDto>();
	}
}
