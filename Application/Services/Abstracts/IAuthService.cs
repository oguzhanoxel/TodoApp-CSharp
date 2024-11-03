using Core.Results;
using Domain.Dtos.User.RequestDtos;
using Domain.Dtos.User.ResponseDtos;

namespace Application.Services.Abstracts;

public interface IAuthService
{
	Task<DataResult<UserResponseDto>> RegisterAsync(RegisterRequestDto dto);
	Task<DataResult<UserResponseDto>> LoginAsync(LoginRequestDto dto);
	Task<Result> LogoutAsync();
}
