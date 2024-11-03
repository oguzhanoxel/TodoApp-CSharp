using Core.Results;
using Domain.Dtos.Todo.RequestDtos;
using Domain.Dtos.Todo.ResponseDtos;

namespace Application.Services.Abstracts;

public interface ITodoService
{
	DataResult<TodoResponseDto> Create(CreateTodoRequestDto dto);
	DataResult<TodoResponseDto> Update(int id, UpdateTodoRequestDto dto);
	DataResult<TodoResponseDto> Delete(int id);
	DataResult<List<TodoResponseDto>> GetAll();
	DataResult<List<TodoResponseDto>> GetAllByUserEmail(string email);
	DataResult<TodoResponseDto> GetById(int id);
}
