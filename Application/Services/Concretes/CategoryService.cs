using Application.Rules;
using Application.Services.Abstracts;
using AutoMapper;
using Core.Results;
using Domain.Dtos.Category.RequestDtos;
using Domain.Dtos.Category.ResponseDtos;
using FluentValidation;
using Persistence.Repositories.Abstracts;
using TodoApp.Domain.Models;

namespace Application.Services.Concretes;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateCategoryRequestDto> _createValidator;
	private readonly IValidator<UpdateCategoryRequestDto> _updateValidator;
	private readonly CategoryBusinessRules _businessRules;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CreateCategoryRequestDto> createValidator, IValidator<UpdateCategoryRequestDto> updateValidator, CategoryBusinessRules businessRules)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
		_createValidator = createValidator;
		_updateValidator = updateValidator;
		_businessRules = businessRules;
	}

	public DataResult<CategoryResponseDto> Create(CreateCategoryRequestDto dto)
	{
		var result = _createValidator.Validate(dto);
		if (!result.IsValid) throw new ValidationException(result.Errors);
		
		Category created = _mapper.Map<Category>(dto);
		var category = _categoryRepository.Create(created);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.Created);
	}

	public DataResult<CategoryResponseDto> Delete(int id)
	{
		_businessRules.CategoryShouldExistWhenRequested(id);
		Category? category = _categoryRepository.Get(x => x.Id == id);
		var deleted = _categoryRepository.Delete(category);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deleted);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<CategoryResponseDto>> GetAll()
	{
		var categories = _categoryRepository.GetAll();
		List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CategoryResponseDto> GetById(int id)
	{
		_businessRules.CategoryShouldExistWhenRequested(id);
		Category? category = _categoryRepository.Get(x => x.Id == id);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CategoryResponseDto> Update(int id, UpdateCategoryRequestDto dto)
	{
		var result = _updateValidator.Validate(dto);
		if (!result.IsValid) throw new ValidationException(result.Errors);
		
		_businessRules.CategoryShouldExistWhenRequested(id);
		Category? category = _categoryRepository.Get(x => x.Id == id);
		_mapper.Map(dto, category);
		var updated = _categoryRepository.Update(category);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(updated);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
