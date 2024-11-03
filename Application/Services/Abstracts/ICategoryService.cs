using Core.Results;
using Domain.Dtos.Category.RequestDtos;
using Domain.Dtos.Category.ResponseDtos;

namespace Application.Services.Abstracts;

public interface ICategoryService
{
	DataResult<CategoryResponseDto> Create(CreateCategoryRequestDto dto);
	DataResult<CategoryResponseDto> Update(int id, UpdateCategoryRequestDto dto);
	DataResult<CategoryResponseDto> Delete(int id);
	DataResult<List<CategoryResponseDto>> GetAll();
	DataResult<CategoryResponseDto> GetById(int id);
}
