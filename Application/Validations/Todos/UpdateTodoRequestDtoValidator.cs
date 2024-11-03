﻿using Domain.Dtos.Todo.RequestDtos;
using FluentValidation;

namespace Application.Validations.Todos;

public class UpdateTodoRequestDtoValidator : AbstractValidator<UpdateTodoRequestDto>
{
	public UpdateTodoRequestDtoValidator()
	{
		RuleFor(x => x.Title).NotEmpty().MinimumLength(3);
		RuleFor(x => x.Description).NotEmpty().MinimumLength(3);
		RuleFor(x => x.StartDate).NotEmpty();
		RuleFor(x => x.EndDate).NotEmpty();
		RuleFor(x => x.CategoryId).NotEmpty();
		RuleFor(x => x.UserId).NotEmpty();
	}
}