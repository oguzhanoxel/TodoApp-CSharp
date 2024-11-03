using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Core.Exceptions;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";

		return exception switch
		{
			ValidationException validationException => CreateValidationException(context, validationException),
			BusinessException businessException => CreateBusinessException(context, businessException),
			AuthorizationException authorizationException => CreateAuthorizationException(context, authorizationException),
			_ => CreateInternalException(context, exception),
		};
	}

	private Task CreateAuthorizationException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

		return context.Response.WriteAsync(new AuthorizationProblemDetails
		{
			Status = StatusCodes.Status401Unauthorized,
			Type = "https://example.com/probs/authorization",
			Title = "Authorization exception",
			Detail = exception.Message,
			Instance = ""
		}.ToString());
	}

	private Task CreateBusinessException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

		return context.Response.WriteAsync(new BusinessProblemDetails
		{
			Status = StatusCodes.Status400BadRequest,
			Type = "https://example.com/probs/business",
			Title = "Business exception",
			Detail = exception.Message,
			Instance = ""
		}.ToString());
	}

	private Task CreateValidationException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
		object errors = ((ValidationException)exception).Errors;

		return context.Response.WriteAsync(new ValidationProblemDetails
		{
			Status = StatusCodes.Status400BadRequest,
			Type = "https://example.com/probs/validation",
			Title = "Validation error(s)",
			Detail = "",
			Instance = "",
			Errors = errors
		}.ToString());
	}

	private Task CreateInternalException(HttpContext context, Exception exception)
	{
		context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

		return context.Response.WriteAsync(new ProblemDetails
		{
			Status = StatusCodes.Status500InternalServerError,
			Type = "https://example.com/probs/internal",
			Title = "Internal exception",
			Detail = exception.Message,
			Instance = ""
		}.ToString());
	}
}
