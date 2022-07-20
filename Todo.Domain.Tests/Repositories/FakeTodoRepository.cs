﻿using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

internal class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo) { }

    public void Update(TodoItem todo) { }

    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("Titulo ToDo", DateTime.Now, "NomeUsuario");
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }
}