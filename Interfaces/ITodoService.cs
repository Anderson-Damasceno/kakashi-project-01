using TodoList.Models;

namespace TodoList.Interfaces;

public interface ITodoService
{
    Task<List<Todo>> GetActiveTodosAsync();
    Task NewTodoAsync();
    Task<Todo> UpdateAsync(Todo todo);
    Task RemoveAsync(Todo todo);

}