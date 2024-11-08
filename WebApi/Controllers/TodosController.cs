﻿using Application.Services.Abstracts;
using Domain.Dtos.Todo.RequestDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
	private readonly ITodoService _todoService;

	public TodosController(ITodoService todoService)
	{
		_todoService = todoService;
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	[Authorize(Roles = "User")]
	public IActionResult Create([FromBody] CreateTodoRequestDto dto)
	{
		var result = _todoService.Create(dto);
		return Ok(result);
	}

	[HttpPut("{id:int}")]
	[Authorize(Roles = "Admin")]
	[Authorize(Roles = "User")]
	public IActionResult Update(int id, [FromBody] UpdateTodoRequestDto dto)
	{
		var result = _todoService.Update(id, dto);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpDelete("{id:int}")]
	[Authorize(Roles = "Admin")]
	[Authorize(Roles = "User")]
	public IActionResult Delete([FromRoute] int id)
	{
		var result = _todoService.Delete(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _todoService.GetAll();
		return Ok(result);
	}

	[HttpGet("filtered")]
	public IActionResult GetAllByFilter([FromQuery] string email = "", [FromQuery] string filter = "")
	{
		var result = _todoService.GetAllByFilter(email, filter);
		return Ok(result);
	}

	[HttpGet("{email}/todos")]
	public IActionResult GetAllByUserEmail([FromRoute] string email)
	{
		var result = _todoService.GetAllByUserEmail(email);
		return Ok(result);
	}

	[HttpGet("todos/{id:int}")]
	public IActionResult GetById([FromRoute] int id)
	{
		var result = _todoService.GetById(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}
}
