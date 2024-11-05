using Application.Services.Abstracts;
using Domain.Dtos.User.RequestDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
	private readonly IAuthService _authService;

	public AuthsController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
	{
		var result = await _authService.RegisterAsync(dto);
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}

	[HttpPost("createadmin")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateAdmin([FromBody] RegisterRequestDto dto)
	{
		var result = await _authService.CreateAdminAsync(dto);
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
	{
		var result = await _authService.LoginAsync(dto);
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		var result = await _authService.LogoutAsync();
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}
}
