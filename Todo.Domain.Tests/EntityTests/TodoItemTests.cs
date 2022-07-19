using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _validTodo = new TodoItem("Titulo do ToDo", DateTime.Now, "NomeUsuario");

    [TestMethod]
    public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
    {
        Assert.IsFalse(_validTodo.Done);
    }

    [TestMethod]
    public void Dado_um_todo_marcado_como_concluido_o_mesmo_deve_estar_concluido()
    {
        _validTodo.MarkAsDone();

        Assert.IsTrue(_validTodo.Done);
    }

    [TestMethod]
    public void Dado_um_todo_marcado_como_nao_concluido_o_mesmo_nao_deve_estar_concluido()
    {
        _validTodo.MarkAsDone();
        _validTodo.MarkAsUndone();

        Assert.IsFalse(_validTodo.Done);
    }

    [TestMethod]
    public void Dado_um_novo_titulo_o_titulo_atual_do_todo_deve_ser_igual_ao_novo()
    {
        var novoTitulo = "NovoTitulo";
        _validTodo.UpdateTitle(novoTitulo);

        Assert.AreEqual(novoTitulo, _validTodo.Title);
    }
}