using Core.Results;
using Domain.Dtos.Category.RequestDtos;
using Domain.Dtos.Category.ResponseDtos;

namespace Application.Services.Abstracts;

public interface ICategoryService
{
	Result<CategoryResponseDto> Create(CreateCategoryRequestDto dto);
	Result<CategoryResponseDto> Update(int id, UpdateCategoryRequestDto dto);
	Result<CategoryResponseDto> Delete(int id);
	Result<List<CategoryResponseDto>> GetAll();
	Result<CategoryResponseDto> GetById(int id);
}
