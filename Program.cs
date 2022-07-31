using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/",                     TodoController.Index);
app.MapGet("/todoitems",            TodoController.AllTodos);
app.MapGet("/todoitems/completed",  TodoController.GetCompletedTodos);
app.MapGet("/todoitems/{id}",       TodoController.GetTodo);
app.MapPost("/todoitems",           TodoController.SaveTodo);
app.MapPut("/todoitems/{id}",       TodoController.UpdateTudo);
app.MapDelete("/todoitems/{id}",    TodoController.DeleteTodo);

//if (app.Environment.IsDevelopment())
//{
//  app.UseSwagger();
//  app.UseSwaggerUI();
//}

app.Run();