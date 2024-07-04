using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services;

public class TodoService
{
    private readonly TodoContext _context;

    public TodoService(TodoContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetActiveTodosAsync()
    {
        var list = await _context.Todos
            .Where(e => !e.Done)
            .OrderBy(e => e.Priority)
            .ToListAsync();
        return list;
    }

    public async Task NewTodoAsync()
    {
        _context.Todos.Add(new Todo
        {
            Title = $"Tarefa {DateTime.Now}",
            Description = $"Tarefa {DateTime.Now}",
            CategoryId = 1,
        });
        await _context.SaveChangesAsync();
    }

    public async Task<Todo> UpdateAsync(Todo todo)
    {
        _context.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task RemoveAsync(Todo todo)
    {
        _context.Remove(todo);
        await _context.SaveChangesAsync();
    }
}