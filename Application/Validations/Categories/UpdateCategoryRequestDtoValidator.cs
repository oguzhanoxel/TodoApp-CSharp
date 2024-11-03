using Domain.Dtos.Category.RequestDtos;
using FluentValidation;

namespace Application.Validations.Categories;

public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto>
{
	public UpdateCategoryRequestDtoValidator()
	{
		RuleFor(x => x.Name).NotEmpty();
	}
}
