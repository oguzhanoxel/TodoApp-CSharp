using Core.Results;
using Domain.Dtos.User.RequestDtos;
using Domain.Dtos.User.ResponseDtos;

namespace Application.Services.Abstracts;

public interface IAuthService
{
	Task<Result<UserResponseDto>> RegisterAsync(RegisterRequestDto dto);
	Task<Result<UserResponseDto>> CreateAdminAsync(RegisterRequestDto dto);
	Task<Result<UserResponseDto>> LoginAsync(LoginRequestDto dto);
	Task<Result> LogoutAsync();
}
