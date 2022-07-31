using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    public class TodoController : Controller
    {

        // GET: "/"
        async static public Task<string> Index()
        {
            return "Index Route";
        }

        // GET: "/todoitems"
        async static public Task<List<Todo>> AllTodos(TodoDb db)
        {
            var todoList = await db.Todos.ToListAsync();
            return todoList;
        }

        // GET: "/todoitems/completed"
        async static public Task<List<Todo>> GetCompletedTodos(TodoDb db)
        {
            var completedTodo = await db.Todos.Where(todo => todo.IsCompleted == true).ToListAsync();
            return completedTodo;
        }

        // GET: "/todoitems/{id}"
        async static public Task<IResult?> GetTodo(int id, TodoDb db)
        {
            return await db.Todos.FindAsync(id) is Todo t ? Results.Ok(t) : Results.NotFound();
        }

        // POST: "/todoitems"
        async static public Task<IResult> SaveTodo(Todo todo, TodoDb db)
        {
            db.Todos.Add(todo);
            await db.SaveChangesAsync();
            return Results.Created($"/todoitems/{todo.Id}", todo);
        }

        // PUT: "/todoitems/{id}"
        async static public Task<IResult> UpdateTudo(int id, Todo inputTudo, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return Results.NotFound(id);

            todo.Title = inputTudo.Title;
            todo.IsCompleted = inputTudo.IsCompleted;

            await db.SaveChangesAsync();

            return Results.Ok(inputTudo);
        }

        // DELETE: "/todoitems/{id}"
        async static public Task<IResult?> DeleteTodo(int id, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo is null) return Results.NotFound(id);

            db.Todos.Remove(todo);
            await db.SaveChangesAsync();

            return Results.Ok(todo);
        }
    }
}
