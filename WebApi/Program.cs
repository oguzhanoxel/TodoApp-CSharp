using Application;
using Application.Mappings;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Contexts;
using TodoApp.Domain.Models;

namespace WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddApplicationServices();
			builder.Services.AddPersistenceServices(builder.Configuration);

			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
				options.AddPolicy("User", policy => policy.RequireRole("User"));
			});

			builder.Services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<EfCoreDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.AddAutoMapper(typeof(MappingProfiles));

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCustomExceptionMiddleware(); // ExceptionMiddleware

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
