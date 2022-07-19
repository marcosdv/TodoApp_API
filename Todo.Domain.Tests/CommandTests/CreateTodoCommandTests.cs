﻿using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titudo da Tarefa", DateTime.Now, "NomeDoUsuario");

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        Assert.IsFalse(_invalidCommand.Valid);
    }

    [TestMethod]
    public void Dado_um_comando_valido()
    {
        Assert.IsTrue(_validCommand.Valid);
    }
}