using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApp.Domain.Models;

namespace Persistence.Contexts;

public class EfCoreDbContext : IdentityDbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Todo> Todos { get; set; }
	public DbSet<Category> Categories { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		SeedData(modelBuilder);
	}

	private void SeedData(ModelBuilder modelBuilder)
	{
		var passwordHasher = new PasswordHasher<User>();

		var categories = new List<Category>
		{
			new Category { Id = 1, Name = "Stand Battles" },
			new Category { Id = 2, Name = "Fashion Choices" },
			new Category { Id = 3, Name = "Memorable Quotes" },
			new Category { Id = 4, Name = "Unforgettable Villains" },
			new Category { Id = 5, Name = "Meme Wars" }
		};

		var roles = new List<IdentityRole>
		{
			new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN"},
			new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER"},
		};

		var users = new List<User>
		{
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Joseph", LastName = "Joestar", Email = "joseph@jojo.com", UserName = "joseph" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Jotaro", LastName = "Kujo", Email = "jotaro@jojo.com", UserName = "jotaro" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Dio", LastName = "Brando", Email = "dio@jojo.com", UserName = "dio" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Giorno", LastName = "Giovanna", Email = "giorno@jojo.com", UserName = "giorno" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Josuke", LastName = "Higashikata", Email = "josuke@jojo.com", UserName = "josuke" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Jonathan", LastName = "Joestar", Email = "jonathan@jojo.com", UserName = "jonathan" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Bruno", LastName = "Bucciarati", Email = "bruno@jojo.com", UserName = "bruno" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Rohan", LastName = "Kishibe", Email = "rohan@jojo.com", UserName = "rohan" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Kakyoin", LastName = "Noriaki", Email = "kakyoin@jojo.com", UserName = "kakyoin" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Jean Pierre", LastName = "Polnareff", Email = "polnareff@jojo.com", UserName = "polnareff" },
		};

		users[0].PasswordHash = passwordHasher.HashPassword(users[0], "hermitpurple");
		users[1].PasswordHash = passwordHasher.HashPassword(users[1], "starplatinum");
		users[2].PasswordHash = passwordHasher.HashPassword(users[2], "zaWarudo");
		users[3].PasswordHash = passwordHasher.HashPassword(users[3], "goldenwind");
		users[4].PasswordHash = passwordHasher.HashPassword(users[4], "crazydiamond");
		users[5].PasswordHash = passwordHasher.HashPassword(users[5], "sunlightyellow");
		users[6].PasswordHash = passwordHasher.HashPassword(users[6], "zippers");
		users[7].PasswordHash = passwordHasher.HashPassword(users[7], "heaven'sdoor");
		users[8].PasswordHash = passwordHasher.HashPassword(users[8], "cherryeater");
		users[9].PasswordHash = passwordHasher.HashPassword(users[9], "silverchariot");

		var todos = new List<Todo>
		{
			new Todo { Id = 1, Title = "Learn how to pose dramatically", Description = "Every time I walk into a room, I must strike a pose.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), CategoryId = 2, UserId = users[0].Id.ToString() },
			new Todo { Id = 2, Title = "Plan the ultimate revenge against Jotaro", Description = "Must come up with a clever scheme.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), CategoryId = 4, UserId = users[2].Id.ToString() },
			new Todo { Id = 3, Title = "Create a meme with Rohan", Description = "Use his face in the next viral meme.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), CategoryId = 5, UserId = users[7].Id.ToString() },
			new Todo { Id = 4, Title = "Investigate the mystery of the missing pizza", Description = "Did someone eat it or did a Stand steal it?", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CategoryId = 1, UserId = users[4].Id.ToString() },
			new Todo { Id = 5, Title = "Write a new chapter for my manga", Description = "Make sure it includes a strong villain.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), CategoryId = 3, UserId = users[7].Id.ToString() },
			new Todo { Id = 6, Title = "Train my Stand to do the dishes", Description = "It’s about time my Stand helped with chores!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CategoryId = 1, UserId = users[0].Id.ToString() },
			new Todo { Id = 7, Title = "Have a fashion showdown with Jotaro", Description = "I need to prove my style is superior!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), CategoryId = 2, UserId = users[1].Id.ToString() },
			new Todo { Id = 8, Title = "Find out who stole my spaghetti", Description = "No one messes with a Joestar’s food!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CategoryId = 4, UserId = users[0].Id.ToString() },
			new Todo { Id = 9, Title = "Record Dio's best quotes", Description = "Need material for the next meme.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), CategoryId = 3, UserId = users[2].Id.ToString() },
			new Todo { Id = 10, Title = "Discuss friendship with Kakyoin", Description = "We need to strengthen our bond.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(4), CategoryId = 1, UserId = users[8].Id.ToString() },
			new Todo { Id = 11, Title = "Start a Stand-up comedy routine", Description = "Use all my JoJo experiences for laughs.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), CategoryId = 5, UserId = users[1].Id.ToString() },
			new Todo { Id = 12, Title = "Challenge Josuke to a hair-styling contest", Description = "Let’s see who has the best hair!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), CategoryId = 2, UserId = users[4].Id.ToString() },
			new Todo { Id = 13, Title = "Create a JoJo-themed escape room", Description = "Make it as bizarre as possible!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14), CategoryId = 5, UserId = users[7].Id.ToString() },
			new Todo { Id = 14, Title = "Write an epic ballad about my adventures", Description = "Must include lots of drama and betrayal.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), CategoryId = 3, UserId = users[6].Id.ToString() },
			new Todo { Id = 15, Title = "Host a Stand Battle tournament", Description = "The winner gets a pizza!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(15), CategoryId = 1, UserId = users[2].Id.ToString() },
			new Todo { Id = 16, Title = "Develop a new Stand ability", Description = "It should be something cool and over-the-top!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(8), CategoryId = 1, UserId = users[3].Id.ToString() },
			new Todo { Id = 17, Title = "Compose a theme song for my Stand", Description = "Make it catchy and powerful!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(6), CategoryId = 5, UserId = users[1].Id.ToString() },
			new Todo { Id = 18, Title = "Have a showdown with a rival Stand user", Description = "Time to prove my strength!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(4), CategoryId = 1, UserId = users[5].Id.ToString() },
			new Todo { Id = 19, Title = "Create a cosplay for the next convention", Description = "It needs to be legendary!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(12), CategoryId = 2, UserId = users[6].Id.ToString() },
			new Todo { Id = 20, Title = "Plan a trip to the Joestar family mansion", Description = "I need to find some cool artifacts!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(20), CategoryId = 4, UserId = users[0].Id.ToString() }
		};

		modelBuilder.Entity<IdentityRole>().HasData(roles);
		modelBuilder.Entity<Category>().HasData(categories);
		modelBuilder.Entity<User>().HasData(users);
		modelBuilder.Entity<Todo>().HasData(todos);
	}
}
