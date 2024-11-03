using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Abstracts;
using Persistence.Repositories.Concretes;

namespace Persistence;

public static class PersistenceServiceRegistration
{
	public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<ITodoRepository, EfTodoRepository>();
		services.AddScoped<ICategoryRepository, EfCategoryRepository>();

		services.AddDbContext<EfCoreDbContext>(options => options.UseSqlServer(
			configuration.GetConnectionString("SqlConnection")));

		return services;
	}
}
