using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Sua tarefa está incorreta", command.Notifications);

        //Gerar o TodoItem
        var todo = new TodoItem(command.Title, command.Date, command.User);

        //Salva no banco
        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Sua tarefa está incorreta", command.Notifications);

        //Recupera o TodoItem do Banco
        var todo = _repository.GetById(command.Id, command.User);

        //Altera o titulo
        todo.UpdateTitle(command.Title);

        //Salva no banco
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Sua tarefa está incorreta", command.Notifications);

        //Recupera o TodoItem do Banco
        var todo = _repository.GetById(command.Id, command.User);

        //Marca como concluido
        todo.MarkAsDone();

        //Salva no banco
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Sua tarefa está incorreta", command.Notifications);

        //Recupera o TodoItem do Banco
        var todo = _repository.GetById(command.Id, command.User);

        //Marca como nao concluido
        todo.MarkAsUndone();

        //Salva no banco
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }
}