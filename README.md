# TodoApp

TodoApp is a simple task management application built with C# and .NET. It demonstrates the use of clean architecture principles, repository pattern, and in-memory data storage.

## Project Structure

The project is organized into several namespaces:

- `TodoApp.Core`: Contains core interfaces and base classes.
- `TodoApp.Domain`: Defines the main entities (User and Todo).
- `TodoApp.Persistence`: Implements data storage and retrieval.
- `UnitTest`: Contains unit tests for the application.

### Key Components

1. **Models**:
   - `Entity`: Base class for all entities.
   - `User`: Represents a user in the system.
   - `Todo`: Represents a todo item.

2. **Repositories**:
   - `IRepository<T>`: Generic repository interface.
   - `BaseRepository<T>`: Base implementation of the repository pattern.
   - `ITodoRepository` and `TodoRepository`: Specific repository for Todo items.
   - `IUserRepository` and `UserRepository`: Specific repository for User entities.

3. **In-Memory Database**:
   - `InMemoryDbContext`: Simulates a database using in-memory collections.

4. **Unit Tests**:
   - `TodoRepositoryUnitTest`: Tests for the TodoRepository.

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/oguzhanoxel/TodoApp-CSharp.git
   ```

2. Open the solution in Visual Studio or your preferred IDE.

3. Build the solution to restore NuGet packages and compile the project.

4. Run the unit tests to ensure everything is working correctly.

## Usage

The application currently provides in-memory storage for Users and Todos. You can use the repositories to perform CRUD operations on these entities.

Example usage:

```csharp
var userRepository = new UserRepository();
var todoRepository = new TodoRepository();

var user = new User { Name = "Oğuzhan Öksel" };
userRepository.Add(user);

var todos = todoRepository.GetAll();
foreach (var todo in todos)
{
    Console.WriteLine($"Todo: {todo.Title}, Status: {todo.IsCompleted}");
}
```



