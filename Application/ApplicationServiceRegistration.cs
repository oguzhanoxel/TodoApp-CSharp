using Application.Rules;
using Application.Services.Abstracts;
using Application.Services.Concretes;
using Application.Validations.Categories;
using Application.Validations.Todos;
using Domain.Dtos.Category.RequestDtos;
using Domain.Dtos.Todo.RequestDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<ITodoService, TodoService>();

		services.AddScoped<UserBusinessRules>();
		services.AddScoped<CategoryBusinessRules>();
		services.AddScoped<TodoBusinessRules>();

		services.AddScoped<IValidator<CreateCategoryRequestDto>, CreateCategoryRequestDtoValidator>();
		services.AddScoped<IValidator<UpdateCategoryRequestDto>, UpdateCategoryRequestDtoValidator>();
		services.AddScoped<IValidator<CreateTodoRequestDto>, CreateTodoRequestDtoValidator>();
		services.AddScoped<IValidator<UpdateTodoRequestDto>, UpdateTodoRequestDtoValidator>();

		return services;
	}
}
