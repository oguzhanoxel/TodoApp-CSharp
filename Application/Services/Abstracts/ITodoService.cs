using Core.Results;
using Domain.Dtos.Todo.RequestDtos;
using Domain.Dtos.Todo.ResponseDtos;

namespace Application.Services.Abstracts;

public interface ITodoService
{
	Result<TodoResponseDto> Create(CreateTodoRequestDto dto);
	Result<TodoResponseDto> Update(int id, UpdateTodoRequestDto dto);
	Result<TodoResponseDto> Delete(int id);
	Result<List<TodoResponseDto>> GetAll();
	Result<List<TodoResponseDto>> GetAllByFilter(string email = null, string filter = null);
	Result<List<TodoResponseDto>> GetAllByUserEmail(string email);
	Result<TodoResponseDto> GetById(int id);
}
