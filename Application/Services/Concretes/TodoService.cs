﻿using Application.Rules;
using Application.Services.Abstracts;
using AutoMapper;
using Core.Results;
using Domain.Dtos.Todo.RequestDtos;
using Domain.Dtos.Todo.ResponseDtos;
using FluentValidation;
using Persistence.Repositories.Abstracts;
using TodoApp.Domain.Models;

namespace Application.Services.Concretes;

public class TodoService : ITodoService
{
	private readonly ITodoRepository _todoRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateTodoRequestDto> _createValidator;
	private readonly IValidator<UpdateTodoRequestDto> _updateValidator;
	private readonly TodoBusinessRules _businessRules;

	public TodoService(ITodoRepository todoRepository, IMapper mapper, IValidator<CreateTodoRequestDto> createValidator, IValidator<UpdateTodoRequestDto> updateValidator, TodoBusinessRules businessRules)
	{
		_todoRepository = todoRepository;
		_mapper = mapper;
		_createValidator = createValidator;
		_updateValidator = updateValidator;
		_businessRules = businessRules;
	}

	public DataResult<TodoResponseDto> Create(CreateTodoRequestDto dto)
	{
		var result = _createValidator.Validate(dto);

		if (!result.IsValid) throw new ValidationException(result.Errors);
		else
		{
			Todo created = _mapper.Map<Todo>(dto);
			var todo = _todoRepository.Create(created);
			TodoResponseDto response = _mapper.Map<TodoResponseDto>(todo);

			return ResultFactory.Success(
				response,
				statusCode: System.Net.HttpStatusCode.Created);
		}
	}

	public DataResult<TodoResponseDto> Delete(int id)
	{
		_businessRules.TodoShouldExistWhenRequested(id);
		Todo? todo = _todoRepository.Get(x => x.Id == id);
		var deleted = _todoRepository.Delete(todo);
		TodoResponseDto response = _mapper.Map<TodoResponseDto>(deleted);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<TodoResponseDto>> GetAll()
	{
		var todos = _todoRepository.GetAll();
		List<TodoResponseDto> response = _mapper.Map<List<TodoResponseDto>>(todos);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<TodoResponseDto>> GetAllByUserEmail(string email)
	{
		var todos = _todoRepository.GetAll(x => x.User.Email == email);
		List<TodoResponseDto> response = _mapper.Map<List<TodoResponseDto>>(todos);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<TodoResponseDto> GetById(int id)
	{
		_businessRules.TodoShouldExistWhenRequested(id);
		Todo? todo = _todoRepository.Get(x => x.Id == id);
		TodoResponseDto response = _mapper.Map<TodoResponseDto>(todo);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<TodoResponseDto> Update(int id, UpdateTodoRequestDto dto)
	{
		var result = _updateValidator.Validate(dto);

		if (!result.IsValid) throw new ValidationException(result.Errors);
		else
		{
			_businessRules.TodoShouldExistWhenRequested(id);
			Todo? todo = _todoRepository.Get(x => x.Id == id);
			_mapper.Map(dto, todo);
			var updated = _todoRepository.Update(todo);
			TodoResponseDto response = _mapper.Map<TodoResponseDto>(updated);

			return ResultFactory.Success(
				response,
				statusCode: System.Net.HttpStatusCode.OK);
		}
	}
}
