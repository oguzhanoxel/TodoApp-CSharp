using Core.Results;
using Domain.Dtos.User.ResponseDtos;

namespace Application.Services.Abstracts;

public interface IUserService
{
	Task<DataResult<List<UserResponseDto>>> GetAllAsync();
	Task<DataResult<UserResponseDto>> GetByIdAsync(string id);
}
