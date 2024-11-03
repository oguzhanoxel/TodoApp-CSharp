using Core.Exceptions;
using Persistence.Repositories.Abstracts;
using TodoApp.Domain.Models;

namespace Application.Rules;

public class CategoryBusinessRules
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryBusinessRules(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public void CategoryShouldExistWhenRequested(int id)
	{
		Category? category = _categoryRepository.Get(x => x.Id == id);
		if (category is null) throw new BusinessException("Not Found");
	}
}
