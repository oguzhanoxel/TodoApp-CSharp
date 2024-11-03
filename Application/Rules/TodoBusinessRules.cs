using Core.Exceptions;
using Persistence.Repositories.Abstracts;
using TodoApp.Domain.Models;

namespace Application.Rules;

public class TodoBusinessRules
{
	private readonly ITodoRepository _todoRepository;

	public TodoBusinessRules(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

	public void TodoShouldExistWhenRequested(int id)
	{
		Todo? todo = _todoRepository.Get(x => x.Id == id);
		if (todo is null) throw new BusinessException("Not Found");
	}
}
