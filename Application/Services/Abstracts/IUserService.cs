using Core.Results;
using Domain.Dtos.User.ResponseDtos;

namespace Application.Services.Abstracts;

public interface IUserService
{
	Task<Result<List<UserResponseDto>>> GetAllAsync();
	Task<Result<UserResponseDto>> GetByIdAsync(string id);
}
