﻿using Core.Repository;
using TodoApp.Domain.Models;

namespace Persistence.Repositories.Abstracts;

public interface ITodoRepository : IRepository<Todo, int>
{

}
