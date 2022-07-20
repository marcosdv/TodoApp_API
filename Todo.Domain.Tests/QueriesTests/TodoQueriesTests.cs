﻿using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests;

[TestClass]
public class TodoQueriesTests
{
    private List<TodoItem> _items;

    public TodoQueriesTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "usuarioA"));
        _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuarioB"));
        _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "usuarioB"));
        _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "usuarioA"));
        _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "usuarioA"));
    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuarioA()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuarioA"));

        Assert.AreEqual(3, result.Count());
    }
}
